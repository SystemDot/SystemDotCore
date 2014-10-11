Feature: Synchronous bootstrap build
	In order to bootstrap initialise an application
	I want to build and run bootstrap actions

Scenario: Synchronously run a bootstrap action
	Given I have registered a build action with the bootstrapper to register a component with ioc
	And I have registered an asynchronous build action with the bootstrapper to register a component with ioc
	When I build the bootstrapper
	Then I should be able to resolve the registered component from ioc
	And I should be able to resolve the asynchronously registered component from ioc

Scenario: Synchronously run bootstrap actions contained in bootstrap build components
	Given I have a bootstrap build component that registers a component with ioc
	When I build the bootstrapper
	Then I should be able to resolve the component registered in the bootstrap build component from ioc
	
Scenario: Synchronously run multiple bootstrap actions using build order
	Given I have registered an 'Ultimate' build action with the bootstrapper to add 1 to a collection
	And I have registered a 'VeryLate' build action with the bootstrapper to add 2 to a collection
	And I have registered a 'Late' build action with the bootstrapper to add 3 to a collection
	And I have registered an 'Anytime' build action with the bootstrapper to add 4 to a collection
	And I have registered an 'Early' build action with the bootstrapper to add 5 to a collection
	When I build the bootstrapper
	Then the item in position 0 in the collection should be 5
	And the item in position 1 in the collection should be 4
	And the item in position 2 in the collection should be 3
	And the item in position 3 in the collection should be 2
	And the item in position 4 in the collection should be 1

