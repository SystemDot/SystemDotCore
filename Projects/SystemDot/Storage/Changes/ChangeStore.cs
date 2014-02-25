using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SystemDot.Core;
using SystemDot.Serialisation;
using SystemDot.Storage.Changes.Upcasting;

namespace SystemDot.Storage.Changes
{
    public abstract class ChangeStore : Disposable
    {
        readonly ISerialiser serialiser;
        readonly ChangeUpcasterRunner upcasterRunner;

        protected ChangeStore(ISerialiser serialiser, ChangeUpcasterRunner upcasterRunner)
        {
            Contract.Requires(serialiser != null);
            Contract.Requires(upcasterRunner != null);

            this.serialiser = serialiser;
            this.upcasterRunner = upcasterRunner;
        }

        public abstract void Initialise();

        public void StoreChange(string changeRootId, Change change)
        {
            change.Version = Change.LatestVersion;
            StoreChange(changeRootId, change, SerialiseChange);
        }

        protected abstract void StoreChange(
            string changeRootId, 
            Change change, Func<Change, byte[]> serialiseAction);

        byte[] SerialiseChange(Change toDeserialise)
        {
            return serialiser.Serialise(toDeserialise);
        }

        public IEnumerable<Change> GetChanges(string changeRootId)
        {
            return GetChanges(changeRootId, DeserialiseAndUpcastChange);
        }

        Change DeserialiseAndUpcastChange(byte[] toDeserialise)
        {
            return upcasterRunner.UpcastIfRequired(DeserialiseChange(toDeserialise));
        }

        Change DeserialiseChange(byte[] toDeserialise)
        {
            return serialiser
                .Deserialise(toDeserialise)
                .As<Change>();
        }

        protected abstract IEnumerable<Change> GetChanges(
            string changeRootId, 
            Func<byte[], Change> deserialiseAction);

        public IEnumerable<ChangeDescription> DescribeAllChanges()
        {
            return GetChangeDescriptions(DeserialiseToDescription);
        }

        ChangeDescription DeserialiseToDescription(string rootId, long sequence, byte[] change)
        {
            return new ChangeDescription
            {
                RootId = rootId, 
                Sequence = sequence, 
                Change = serialiser.DeserialiseToString(change)
            };
        }

        protected abstract IEnumerable<ChangeDescription> GetChangeDescriptions(
            Func<string, long, byte[], ChangeDescription> descriptionCreator);
    }
}