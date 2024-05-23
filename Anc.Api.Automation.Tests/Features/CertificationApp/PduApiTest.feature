Feature: PDU Api Service Automation

This feature covers the PDU API Automation
Background: 
	Given Generate access token for PDU application


Scenario: Verify claim review rule details
	When  Get claim review rules details
	Then  Verify claim review rule response details


Scenario: Execute and verify maxlimitpdurule claim review rule for a pdu claim preview mode
	When  Post the MaxLimitPduRule review rule for an pdu claim
	Then  Verify that executed maxlimitpdurule claim review rule 
