Feature: Set User Password
	Simple calculator for adding two numbers

Background: 
	Given A Newly Configured System

Scenario: Cannot Set Password When not logged In
	Given User User Exists
	 And Password for User is set to OldPasswod
	When I set user User's password to Password
	Then Unauthorized
     And Password for user User is set to OldPasswod

Scenario: Cannot Set Password When logged in as a different user
	Given User UserA Exists
	  And User UserA is Logged In
	Given User UserB Exists
	  And Password for UserB is set to OldPasswod
	When I set user UserB's password to Password
	Then Unauthorized
	 And Password for user UserB is set to OldPasswod

Scenario: Can Set Password When logged in as a same user
	Given User UserA Exists
	  And User UserA is Logged In
	  And Password for UserA is set to OldPasswod
	When I set user UserA's password to Password
	Then Success
	 And Password for user UserA is set to Password

Scenario: Admin can set a User's password 
	Given User Admin Exists
	  And User Admin is in Admin Role
	  And User Admin is Logged In
	Given User User Exists
	  And Password for User is set to OldPasswod
	 When I set user User's password to Password
	 Then Success
	  And Password for user User is set to Password
