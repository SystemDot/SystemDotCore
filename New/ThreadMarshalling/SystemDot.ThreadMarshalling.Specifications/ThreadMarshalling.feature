Feature: ThreadMarshalling
	In order to use the thread marshaller
	I want to be able to resolve it in ioc with out registering it

Scenario: Resolving marshaller
	When I have initialised bootstrapping
	Then I should be able to resolve the marshaller
