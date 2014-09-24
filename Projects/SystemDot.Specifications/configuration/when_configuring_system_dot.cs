using SystemDot.Configuration;
using SystemDot.Core;
using SystemDot.Environment;
using SystemDot.Files;
using SystemDot.Http;
using SystemDot.Http.Builders;
using SystemDot.Ioc;
using SystemDot.Messaging;
using SystemDot.Messaging.Simple;
using SystemDot.Serialisation;
using SystemDot.Storage.Changes;
using SystemDot.Storage.Changes.Upcasting;
using SystemDot.ThreadMarshalling;
using Machine.Specifications;

namespace SystemDot.Specifications.configuration
{
    [Subject(SpecificationGroup.Description)]
    public class when_configuring_system_dot
    {
        static IIocContainer container;

        Establish context = () => container = new IocContainer();

        Because of = () => Configure
            .SystemDot()
            .ResolveReferencesWith(container)
            .Initialise();

        It should_have_correctly_registered_the_file_system_components = () =>
            container.Resolve<IFileSystem>().ShouldNotBeNull();
        
        It should_have_correctly_registered_the_application_components = () =>
            container.Resolve<IApplication>().ShouldNotBeNull();
        
        It should_have_correctly_registered_the_local_machine_components = () =>
            container.Resolve<ILocalMachine>().ShouldNotBeNull();

        It should_have_correctly_registered_the_http_components = () =>
            container.Resolve<IHttpServerBuilder>().ShouldNotBeNull();

        It should_have_correctly_registered_the_web_request_components = () =>
            container.Resolve<IWebRequestor>().ShouldNotBeNull();

        It should_have_correctly_registered_the_serialisation_components = () =>
            container.Resolve<ISerialiser>().ShouldNotBeNull();

        It should_have_correctly_registered_the_storage_components = () =>
            container.Resolve<ChangeUpcasterRunner>().ShouldNotBeNull();
        
        It should_have_correctly_registered_the_thread_marshalling_components = () =>
            container.Resolve<IMainThreadMarshaller>().ShouldNotBeNull();
    }
}