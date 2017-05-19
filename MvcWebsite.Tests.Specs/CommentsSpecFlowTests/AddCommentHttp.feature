Feature: AddCommentHttp
	I want to add and check for a comment via Http POST and GET

@mytag
Scenario: Adding a comment via Http POST
	Given I post a comment to the comments controller
	When I get the comments
	Then the comment I posted is available
