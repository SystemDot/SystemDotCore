Feature: Asynchronous bootstrap build
	In order to bootstrap initialise an application
	I want to build and run bootstrap actions

Scenario: Asynchronously run a bootstrap action
	Given I have registered an asynchronous build action with the bootstrapper to register a component with ioc
	And I have registered a build action with the bootstrapper to register a component with ioc
	When I build the bootstrapper asynchronously
	Then I should be able to resolve the asynchronously registered component from ioc
	And I should be able to resolve the registered component from ioc