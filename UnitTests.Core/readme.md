# Unit Test Convetions

- Each folder/namespace should group a class under test.
  - This is to provide support for Fact unit test classes and Theory unit test classes.
  - Given a UserService, a Fact class would be UserTests, and a Theory class would be UserTheories
  - Theory classes would hold larger data sets for batch testing, perhaps as partials. 
- Each class should represent one class under test.
- Each function in the test class should test only one function in the class under test.

## Fact Function Naming Convention

UnitOfWork__StateUnderTest__ExpectedBehavior

### Example:

Insert_GivenUser_ReturnsUserWithId