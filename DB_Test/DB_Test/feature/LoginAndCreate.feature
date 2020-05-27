Feature: Login and new product creation
	As a user
	I want to login to the database
	So I can create a new product row



	Scenario: LoginAndCreate

	Given I open "http://localhost:5000/" url
	When I type my login data
	And I press the Enter button
	And I click on "All Products" link
	And I click on "Create new" button
	And I fill the first field "ProductName" with "Biscuits"
	And I pick "Confections"  on the first dropdown "CategoryId"
	And I pick "Pavlova, Ltd." on the second dropdown "SupplierId"
	And I fill the second field "UnitPrice" with "15"
	And I click on "submit" button to create a new product
	Then I check that "Biscuits" product has been created







