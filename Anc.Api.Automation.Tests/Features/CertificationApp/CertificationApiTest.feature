Feature: Certification Api Service Automation

This feature covers the Certification API Automation
Background:
	Given Generate access token for certification service

@Qa @Can @Prod @local @timeout:30 @debug @CertApi
Scenario: Verify exam details
	When  Get exam details 
	Then  Verify exam details

@Qa @Can @Prod @local @timeout:30 @debug @CertApi
Scenario: Verify certification details by ID
	When  Get certification details by ID
	Then  Verify certification details

@Qa @Can @local @timeout:30 @debug @CertApi @rten
Scenario: Verify that rten modify appointment service for exam scheduled an event
	When  Post rten modify appointment to schedule an event
	Then  Verify that schedule event should be created successfully

@Qa @Can @local @timeout:30 @debug @CertApi @rten
Scenario: Verify that rten modify appointment service for exam rescheduled an event
	When  Post rten modify appointment to reschedule an event
	Then  Verify that reschedule event should be created successfully

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify CCR cycle by id
	When  Get CCR cycle details by id
	Then  Verify CCR cycle details

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify CCR cycle for given certification id
	When  Get cycle for given certification id
	Then  Verify cycle details for given certification id

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify cycle by CCR cycle id and certification id
	When  Get cycle by CCR cycle id and certification id
	Then  Verify cycle details for given CCR cycle id and certification id

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify certification details by using specific user access token
	When  Get certification details by using specific user access token
	Then  Verify certification details by using specific user access token

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify all valid transition for given certification
	When  Get and verify all valid transition for given certification

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify valid re-certification transition event for given certification
	When  Get valid re-certification transition event for given certification
	Then  Verify re-certification transition event details

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify valid transition event for certification by id
	When  Get valid transition event for certification by id
	Then  Verify valid transition event response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify valid re-certification transition event for certification by id
	When  Get valid re-certification transition event for certification by id
	Then  Verify valid re-certification transition event response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify buseiness rule settings
	When  Get business rule settings
	Then  Verify business rule sttings response

@Qa @Can @Prod @local @timeout:30 @debug @CertApi
Scenario: Verify CCR settings
	When  Get ccr settings
	Then  Verify ccr sttings response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify certification configurations settings
	When  Get certification configurations settings
	Then  Verify certification configurations sttings response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify certification configurations settings by certification type
	When  Get certification configurations settings by certification type
	Then  Verify certification configurations sttings by certification type response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify raw certification configurations settings
	When  Get raw certification configurations settings
	Then  Verify raw certification configurations sttings response

@Qa @Can @local @timeout:30 @debug @CertApi	
Scenario: Verify raw certification configurations settings by id
	When  Get raw certification configurations settings by id
	Then  Verify raw certification configurations sttings by id response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify raw certification configurations settings by certification type
	When  Get raw certification configurations settings by certification type
	Then  Verify raw certification configurations sttings by certification type response

@Qa @Can @Prod @local @timeout:30 @debug @CertApi
Scenario: Verify certification general settings
	When  Get certification general settings
	Then  Verify certification general sttings response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify enterprise settings
	When  Get enterprise settings
	Then  Verify enterprise sttings response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify field validation settings
	When  Get field validation settings
	Then  Verify field validation sttings response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify prerequisites to eligible for a specified certification type
	When  Get prerequisites to eligible for a specified certification type
	Then  Verify prerequisites to eligible for a specified certification type response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify prerequisites to apply for a specified certification type
	When  Get prerequisites to apply for a specified certification type
	Then  Verify prerequisites to apply for a specified certification type response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor inbound transactions by date range
	When  Get exam vendor inbound transactions by date range
	Then  Verify exam vendor inbound transactions details by date range

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor inbound transactions by id
	When  Get exam vendor inbound transactions by id
	Then  Verify exam vendor inbound transactions details from id

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor inbound transactions by person id
	When  Get exam vendor inbound transactions by person id
	Then  Verify exam vendor inbound transactions details from person id

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor outbound message events by date range
	When  Get exam vendor outbound message events by date range
	Then  Verify exam vendor outbound message events details by date range

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor outbound message events by id
	When  Get exam vendor outbound message events by id
	Then  Verify exam vendor outbound message events details from id

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor outbound message events by person id
	When  Get exam vendor outbound message events by person id
	Then  Verify exam vendor outbound message events details from person id

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify member type by given person id
	When  Get the member type by given person id
	Then  Verify member type details by given person id
	
@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify the certification details for an given user
	When  Get the certification details for given user
	Then  Verify the details for given user

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify that certify and establish certification for the given application
	When  Submit certify and establish certification event for the given application
	Then  Verify the established certification details for given application

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify new CCR cycle added for given certification id
    When  Post add new ccr cycle for given certification id
    Then  Verify new ccr cycle added for given certification id 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam by eligibility id
    When  Get exam details by eligibility id
    Then  Verify respone details for exam by eligibility id 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam form for an exam
    When  Get exam form details for an exam
    Then  Verify exam form respone details for an exam 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam results for an exam id
    When  Get exam results for an exam id
    Then Verify exam results respone details for an exam id 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify vendor availability
    When Get vendor availability
    Then Verify respone details for vendor availability 

@Qa @Can @Prod @local @timeout:30 @debug @CertApi
Scenario: Verify all active vendor availability
    When Get all active vendor availability
    Then Verify all active vendor availability details 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exams for given person
    When Get exams for given person
    Then Verify exams response for given person 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exams for given person and certification type
    When Get exams for given person and certification type
    Then Verify exams response for given person and certification type 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify active exams for given person and certification type
    When Get active exams for given person and certification type
    Then Verify active exams response for given person and certification type

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam security result by ID
    When  Get exam security details by ID
    Then  Verify exam security details 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify all exam security result by ID
    When  Get all exam security details by flaggedOnly
    Then  Verify all exam security details 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify an exam security result by examId
    When  Get exam security result by examId
    Then  Verify an exam security result by examId 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify an exam security result to CRM by examId
    When  Get exam security result to CRM by examId
    Then  Verify an exam security result to CRM by examId 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify an exam security summary result by personId
    When  Get exam security summary result by personId
    Then  Verify an exam security summary result by personId

@Qa @Can @local @timeout:30 @debug @CertApi @DB
Scenario: Verify that db can be readable through ado
	When  Test and verify to read a value from db via ado

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that application eligible to pay event sent to servicebus
	When  Publish and verify application eligible to pay event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that panel review failure event sent to servicebus
	When  Publish and verify panel review failure event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that course completed event sent to servicebus
	When  Publish and verify course completed event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that eligibility expired event sent to servicebus
	When  Publish and verify eligibility expired event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam accommodation approved event sent to servicebus
	When  Publish and verify exam accommodation rejected event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam accommodation rejected event sent to servicebus
	When  Publish and verify exam accommodation rejected event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam accommodation requested event sent to servicebus
	When  Publish and verify exam accommodation requested event sent to servicebus

	@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam purchased event sent to servicebus
	When  Publish and verify exam purchased event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam details completed event sent to servicebus
	When  Publish and verify exam details completed event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam taken event sent to servicebus
	When  Publish and verify exam taken event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that exam scheduled event sent to servicebus
	When  Publish and verify exam scheduled event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @ServiceBus
Scenario: Verify that new certification event sent to servicebus
	When  Publish and verify new certification event sent to servicebus

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify that given person is an active panel reviewer
	When  Get the panel reviewer details for given user
	Then  Verify the panel reviewr details for given user

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify that given person certification is locked out of any credential and in a waiting period for any credential
	When  Get the person certification details for given user
	Then  Verify the details of the person certification

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify the certification status for given person access token
	When  Get the certification status for given user
	Then  Verify certification status details for given user

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify can purchase sku is eligible for given person and sku
	When  Get the can purchase for given person and sku
	Then  Verify the person is eligible for given sku

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify prerequisites details for a given person to apply for a specified certification type
	When  Get prerequisites needed for a given person to apply for a specified certification type
	Then  Verify apply prerequisites details for a given person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify prerequisites needed for a given person for eligibility for a specified certification type
	When  Get prerequisites needed for a given person for eligibility for a specified certification type
	Then  Verify eligibility prerequisites details for a given person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify that application is waiting for a given person and certification type
	When  Get is waiting for a given person and certification type
	Then  Verify waiting period details for a given person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify that certification can renew for a given person and certification type
	When  Get is can renew for a given person and certification type
	Then  Verify can renew details for a given person

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify that eligibility get extended for given non application based exam
    When  Post eligibility get extended for given non application based exam
    Then  Verify eligibility get extended for given non application based exam response

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exam vendor message events by exam id
    When  Get exam vendor message events by exam id
    Then  Verify exam vendor message events response by exam id 

@Qa @Can @local @timeout:30 @debug @CertApi @Events
Scenario: Verify certification events for given person id
    When  Get certification events for given person id
    Then  Verify certification events response for given person id 

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify that lms course completed for given person id
    When  Post indicate that given person has completed lms course
    Then  Verify lms course completed response details

@Qa @Can @local @timeout:30 @debug @CertApi
Scenario: Verify exams for given group exam id
    When  Get exams for given group exam id
    Then  Verify exams response for given group exam id

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify that given person is an active provider representative
    When  Get given person is an active provider representative
	Then  Verify response details for given person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify status of certifications for given person id and certification type
    When  Get status of certifications for given person id and certification type
	Then  Verify response details for status of certifications

#Exam Processing Results
@Qa @Can @local @timeout:30 @debug @CertApi @ExamProcessingResult
Scenario: Verify exam processing results by id
	When  Get exam processing results by id
	Then  Verify exam processing result

@Qa @Can @local @timeout:30 @debug @CertApi @ExamProcessingResult
Scenario: Verify queued and dequeued exam processing results
	When  Exam processing result queued
	Then  Get queued exam processing result by id
	And   verify result queued
	When  Exam processing result dequeued
	Then  Verify result dequeued

@Qa @Can @local @timeout:30 @debug @CertApi @ExamProcessingResult
Scenario: Verify the search details for exam processing results for a given person
	When  Get exam processing results for a given person
	Then  Verify exam processing result details

#Profile
@Qa @Can @Prod @local @timeout:30 @debug @CertApi @Profile
Scenario: Verify PMI certification profile for a given person id
	When  Get PMI certification profile for a given person id
	Then  Verify the profile details of PMI certification

@Qa @Can @local @timeout:30 @debug @CertApi @Profile
Scenario: Verify pmi and non pmi certification profile for a given person id
	When  Get pmi and nonpmi certification profile for a given person id
	Then  Verify the profile details of pmi and nonpmi certification

@Qa @Can @local @timeout:30 @debug @CertApi @Profile
Scenario: Verify non pmi certification profile for a given person id
	When  Get nonpmi certification profile for a given person id
	Then  Verify the profile details of nonpmi certification

@Qa @Can @local @timeout:30 @debug @CertApi @Profile
Scenario: Verify profile education for a given person id
	When  Get profile education for a given person id
	Then  Verify the profile education details

#Registry
@Qa @Can @local @timeout:30 @debug @CertApi @Registry
Scenario: Verify credential holder in cert registry
	When  Get credential holder cert registry details
	Then  Verify cert registry details for credential holder

@Qa @Can @local @timeout:30 @debug @CertApi @Exams
Scenario: Verify that process order payment for all cert exams
    When  Post process order payment for all cert exams
    Then  Verify order payment successfull response details

@Qa @Can @local @timeout:30 @debug @CertApi @Email
Scenario: Verify token for an given email template
    When  Get the token for an given email template
    Then  Verify the token details for an email template

@Qa @Can @local @timeout:30 @debug @CertApi @Email
Scenario: Verify personalization for an given email template id
    When  Get the personalization details for an given email template id
    Then  Verify the personalization details for an email template id

@Qa @Can @local @timeout:30 @debug @CertApi @Email
Scenario: Verify attribute for an given email template id
    When  Get the attribute details for an given email template id
    Then  Verify the attribute details for an email template id

@Qa @Can @local @timeout:30 @debug @CertApi @Email
Scenario: Verify and send email for eligible for exam for an user
    When  Send eligible for exam email for a person
    Then  Verify the email sent details

@Qa @Can @local @timeout:30 @debug @CertApi @RequestQueue
Scenario: Verify request queue by id
    When  Get the request queue for a given id
    Then  Verify request queue details for a given id

@Qa @Can @local @timeout:30 @debug @CertApi @RequestQueue
Scenario: Verify request queue item by batch number
    When  Get the request queue for a given batch number
    Then  Verify request queue batch details for a given batch number

@Qa @Can @local @timeout:30 @debug @CertApi @RequestQueue
Scenario: Process and verify request queue batch process and generate certificates for given batch number
    When  Process the batch and generate certificates for given batch number
    Then  Verify the processed batch details

@Qa @Can @local @timeout:30 @debug @CertApi @RequestQueue
Scenario: Process and verify request queue batch process
    When  Process the batch and generate certificates
    Then  Verify the processed batch details

@Qa @Can @local @timeout:30 @debug @CertApi @RequestQueue
Scenario: Verify request queue item by request queue id
    When  Get the request queue item by request queue id
    Then  Verify request queue item details

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Process and verify roster upload through candidate upload queue batch process
    When  Process a candidate upload for an application
    Then  Verify the candidated uploaded details

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify certification status for a given person
    When  Get the status of certification for given person
    Then  Verify status of certification details

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify user can apply for an certification for a given person id
    When  Get the status of user can apply for a certification for a given person id
    Then  Verify apply status of certification for a given person id

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify user can eligible to pay for an certification for a given person id
    When  Get the eligible to pay status of certification for a given person id
    Then  Verify eligible to pay status of certification for a given person id

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify if the given person has a credential that is scheduled for an exam
    When  Get the status of given person has a credential that is scheduled for an exam
    Then  Verify the details of scheduled for an exam for a given person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify if the given person has a credential that is suspended
    When  Get Certification credential status for a given person id
    Then  Verify the suspended status for certified credential

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify the status of the certification
    When  Get the certification status for given certfication type
    Then  Verify the status details for a certification

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify if the given person is eligible to purchase the specified sku
	When  Get the eligible to purchase status for a given person id and sku
	Then  Verify the status of eligible to purchase for agiven person

@Qa @Can @local @timeout:30 @debug @CertApi @Status
Scenario: Verify if the given person has a credential that is expired
	When  Get the status for a given person has a credential that is expired
	Then  Verify the status of person has a credential that is expired