
## Unit Tests

These kind of tests ensure that a single unit of code (a method) works as expected (given an input, it has a predictable output). These tests should be isolated as much as possible. 

### When to use Unit Tests
- **Public functions and classes:** Anything exposed by the API can be reused at various places in ways you have no control over. You should document the expected behavior of the public interfaces with tests.

### When *not* to use Unit Tests
- **Non-public functions or classes:** Anything not exposed by the module can be considered private or an implementation detail, and doesn't need to be tested.
- **Constants**: Testing the value of a constant means copying it, resulting in extra effort without additional confidence that the value is correct.

### What to mock in Unit Tests
- **State of the class under test**: Modifying the state of the class under test directly rather than using methods of the class avoids side effects in test setup.
- **Other exposed classes:** Every class must be tested in isolation to prevent test scenarios from growing exponentially.
- **Asynchronous background operations**: Background operations cannot be stopped or waited on, so they continue running in the following tests and cause side effects.

### What *not* to mock in Unit Tests
- **Non-public functions or classes:** Everything that is not exported can be considered private to the module, and is implicitly tested through the exported classes and functions.
- **Methods of the class under test:** By mocking methods of the class under test, the mocks are tested and not the real methods.
- **Utility functions (pure functions, or those that only modify parameters):** If a function has no side effects because it has no state, it is safe to not mock it in tests.

## Testing Best Practices

### Test Design

Testing at MicroLib is a first class citizen, not an afterthought. It's important we consider the design of our tests as well as we do the design of our features.

When implementing a feature, we think about developing the right capabilities the right way. This helps us narrow our score to a manageable level. When implementing tests for a feature, we must think about developing the right tests, but then cover *all* the important ways the test may fail. This can quickly widen our scope to a level that is difficult to manage.

Test heuristics can help solve this problem. They concisely address many of the common ways bugs manifest themselves in our code. When designing your tests, take time to review known test heuristics to inform your test design.

### Naming your tests

The name of your test should consist of three parts:

- The name of the method being tested.
- The scenario under which it's being tested.
- The expected behavior when the scenario is invoked.

Naming standards are important because they explicitly express the intent of the test. Tests are more than just making sure your code works, they also provide documentation. Just by looking at the suite of unit tests, you should be able to infer the behavior of your code without even looking at the code itself. Additionally, when tests fail, you can see exactly which scenarios don't meet your expectations.

:no_entry: **Bad Test Naming**:

```csharp
[Test]
public void Test_Single()
{
    StringCalculator stringCalculator = new();
    var actual = stringCalculator.Add("0");

	Assert.That(0, Is.EqualTo(actual));
}
```

:heavy_check_mark: **Better Test Naming:**
```csharp
[Test]
public void Add_SingleNumber_ReturnsSameNumber()
{
    StringCalculator stringCalculator = new();
    var actual = stringCalculator.Add("0");

	Assert.That(0, Is.EqualTo(actual));
}
```

### Arranging your tests

**Arrange, Act, Assert** is a common pattern when unit testing. As the name implies, it consists of three main actions:
- *Arrange* your objects, create and set them up as necessary.
- *Act* on an object.
- *Assert* that something is as expected.

This clearly separates what is being tested from the *arrange* and *assert* steps, and limits the chances of intermixing assertions wiht the *act* code.

Readability is one of the most important aspects when writing a test. Separating each of these actions within the test clearly highlight the dependencies required to call your code, how your code is being called, and what you're trying to assert. While it might be possible to combine some steps and reduce the size of your test, the primary goal is to make the test as readable as possible.

:no_entry: **Bad Test Arrangement**:
```csharp
[Test]
public void Add_EmptyString_ReturnsZero()
{
    // Arrange 
    var stringCalculator = new StringCalculator(); 
    
    // Assert 
    Assert.Equal(0, stringCalculator.Add(""));
}
```

:heavy_check_mark: **Good Test Arrangement**:

```csharp
[Test]
public void Add_EmptyString_ReturnsZero()
{
    // Arrange 
    var stringCalculator = new StringCalculator(); 

	// Act
	var actual = stringCalculator.Add("");
	
    // Assert 
    Assert.Equal(0, actual);
}
```

### Writing minimally passing tests

The input to be used in a unit test should be the simplest possible in order to verify the behavior that you're currently testing.

By doing this tests become more resilient to future changes in the codebase. It also is closer to testing behavior over implementation.

Tests that include more information than required to pass the test have a higher chance of introducing errors into the test and can make the intent of the test less clear. When writing tests, you want to focus on the behavior. Setting extra properties on models or using non-zero values when not required, only detracts from what you are trying to prove.

:no_entry:  **Bad Minimal Test**:
```csharp
[Test]
public void Add_EmptyString_ReturnsZero()
{
    var stringCalculator = new StringCalculator(); 
    var actual = stringCalculator.Add("42"); 
    
    Assert.Equal(42, actual);
}
```

:heavy_check_mark: **Good Minimal Test**:

```csharp
[Test]
public void Add_EmptyString_ReturnsZero()
{
    var stringCalculator = new StringCalculator(); 
    var actual = stringCalculator.Add("0"); 
    
    Assert.Equal(0, actual);
}
```

#### Avoiding magic values

Naming variables in unit tests is important, if not more important, than naming variables in production code. Unit tests shouldn't contain magic values.

This prevents the need for the reader of the test to inspect the production code in order to figure out what makes the value special, and explicitly shows what you're trying to _prove_ rather than trying to _accomplish_.

Magic strings can cause confusion to the reader of your tests. If a string looks out of the ordinary, they might wonder why a certain value was chosen for a parameter or return value. This type of string value might lead them to take a closer look at the implementation details, rather than focus on the test.

:no_entry: **Bad: Using Magic Values**:

```csharp
[Test]
public void Add_BigNumber_ThrowsException() 
{ 
    var stringCalculator = new StringCalculator(); 
    Action actual = () => stringCalculator.Add("1001"); 
    
    Assert.Throws<OverflowException>(actual); 
}
```

:heavy_check_mark: **Good: Not using Magic Values**:

```csharp
[Test]
public void Add_BigNumber_ThrowsException() 
{ 
    var stringCalculator = new StringCalculator();
    const string MaximumValue = "1001";
     
    Action actual = () => stringCalculator.Add(MaximumValue); 
    
    Assert.Throws<OverflowException>(actual); 
}
```

#### Avoiding logic in tests

When writing your unit tests, avoid manual string concatenation, logical conditions, such as `if`, `while`, `for`, and `switch`, and other conditions.

By avoiding logic in your unit tests, you lessen the chance of introducing a bug in your tests. It also focuses on the end result, rather than implemtation details.

When you introduce logic into your test suite, the chance of introducing a bug into it increases dramatically. The last place that you want to find a bug is within your test suite. You should have a high level of confidence that your tests work, otherwise, you won't trust them. Tests that you don't trust, don't provide any value. When a test fails, you want to have a sense that something is wrong with your code and that it can't be ignored.

If logic in your test seems unavoidable, consider splitting the test up into two or more different tests.

:no_entry:  **Bad: Having logic in your tests**:

```csharp
[Test]
public void Add_MultipleNumbers_ReturnsCorrectResults() 
{ 
    var stringCalculator = new StringCalculator(); 
    var expected = 0; 
    var testCases = new[] { "0,0,0", "0,1,2", "1,2,3" }; 
    
    foreach (var test in testCases) 
    { 
        Assert.Equal(expected, stringCalculator.Add(test)); 
        expected += 3; 
    }
}
```

:heavy_check_mark: **Better: Avoiding logic in your tests:**
```csharp
[TestCase("0,0,0", 0)]
[TestCase("0,1,2", 3)]
[TestCase("1,2,3", 6)]
public void Add_MultipleNumbers_ReturnsSumOfNumbers(string input, int expected) 
{ 
    var stringCalculator = new StringCalculator(); 
    var actual = stringCalculator.Add(input); 
    
    Assert.Equal(expected, actual); 
}
```

#### Avoid multiple acts

When writing your tests, try to only include one act per test. Common approaches to using only one act include:

-   Create a separate test for each act.
-   Use parameterized tests.

Multiple acts need to be individually Asserted and it isn't guaranteed that all of the Asserts will be executed. In most unit testing frameworks, once an Assert fails in a unit test, the proceeding tests are automatically considered to be failing. This kind of process can be confusing as functionality that is actually working, will be shown as failing.

:no_entry:  **Using Multiple Acts**
```csharp
[Test]
public void Add_EmptyEntries_ShouldBeTreatedAsZero() 
{ 
    // Act 
    var actual1 = stringCalculator.Add(""); 
    var actual2 = stringCalculator.Add(","); 
    
    // Assert 
    Assert.Equal(0, actual1); 
    Assert.Equal(0, actual2); 
}
```

:heavy_check_mark: **Using parameterized tests**
```csharp
[TestCase("", 0)]
[TestCase(",", 0)]
public void Add_EmptyEntries_ShouldBeTreatedAsZero(string input, int expected) 
{ 
	// Arrange 
	var stringCalculator = new StringCalculator(); 
	
	// Act 
	var actual = stringCalculator.Add(input); 
	
	// Assert 
	Assert.Equal(expected, actual); 
}
```

#### Validate private methods by unit testing public methods

In most cases, there shouldn't be a need to test a private method. Private methods are an implementation detail and never exist in isolation. At some point, there's going to be a public facing method that calls the private method as part of its implementation. What you should care about is the end result of the public method that calls into the private one.

Consider the following case:

```csharp
public string ParseLogLine(string input)
{
    var sanitizedInput = TrimInput(input);
    return sanitizedInput;
}

private string TrimInput(string input)
{
    return input.Trim();
}
```

Your first reaction might be to start writing a test for `TrimInput` because you want to ensure that the method is working as expected. However, it's entirely possible that `ParseLogLine` manipulates `sanitizedInput` in such a way that you don't expect, rendering a test against `TrimInput` useless.

The real test should be done against the public facing method `ParseLogLine` because that is what you should ultimately care about.

```csharp
public void ParseLogLine_StartsAndEndsWithSpace_ReturnsTrimmedResult()
{
    var parser = new Parser();

    var result = parser.ParseLogLine(" a ");

    Assert.Equals("a", result);
}
```

With this viewpoint, if you see a private method, find the public method and write your tests against that method. Just because a private method returns the expected result, doesn't mean the system that eventually calls the private method uses the result correctly.

#### Stub static references

One of the principles of a unit test is that it must have full control of the system under test. This principle can be problematic when production code includes calls to static references (for example, `DateTime.Now`). Consider the following code:

```csharp
public int GetDiscountedPrice(int price)
{
    if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
    {
        return price / 2;
    }
    else
    {
        return price;
    }
}
```

How can this code possibly be unit tested? You might try an approach such as:

```csharp
public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
{
    var priceCalculator = new PriceCalculator();

    var actual = priceCalculator.GetDiscountedPrice(2);

    Assert.Equals(2, actual)
}

public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
{
    var priceCalculator = new PriceCalculator();

    var actual = priceCalculator.GetDiscountedPrice(2);

    Assert.Equals(1, actual);
}
```

Unfortunately, you'll quickly realize that there are a couple of problems with your tests.

-   If the test suite is run on a Tuesday, the second test will pass, but the first test will fail.
-   If the test suite is run on any other day, the first test will pass, but the second test will fail.

To solve these problems, you'll need to introduce a _seam_ into your production code. One approach is to wrap the code that you need to control in an interface and have the production code depend on that interface.

```csharp
public interface IDateTimeProvider
{
    DayOfWeek DayOfWeek();
}

public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
{
    if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
    {
        return price / 2;
    }
    else
    {
        return price;
    }
}
```

Your test suite now becomes as follows:

```csharp
public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
{
    var priceCalculator = new PriceCalculator();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

    var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

    Assert.Equals(2, actual);
}

public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
{
    var priceCalculator = new PriceCalculator();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);

    var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

    Assert.Equals(1, actual);
}
```

Now the test suite has full control over `DateTime.Now` and can stub any value when calling into the method.

## Flaky Tests

### What's a flaky test?

It’s a test that sometimes fails, but if you retry it enough times, it passes, eventually.

### What are the potential causes for a test to be flaky?

#### Unclean environment

**Description**: The environment got dirtied by a previous test. The actual cause is probably not the flaky test here.

**Difficulty to reproduce**: Moderate. Usually, running the same spec files until the one that’s failing reproduces the problem.

**Resolution**: Fix the previous tests and/or places where the environment is modified, so that it’s reset to a pristine test after each test.

#### Ordering assertion

**Description**: The test is expecting a specific order in the data under test yet the data is in a non-deterministic order.

**Difficulty to reproduce**: Easy. Usually, running the test locally several times would reproduce the problem.

**Resolution**: Depending on the problem, you might want to:
-   loosen the assertion if the test shouldn’t care about ordering but only on the elements
-   fix the test by specifying a deterministic ordering
-   fix the app code by specifying a deterministic ordering

#### Dataset-specific

**Description**: The test assumes the dataset is in a particular (usually limited) state, which might not be true depending on when the test run during the test suite.

**Difficulty to reproduce**: Moderate, as the amount of data needed to reproduce the issue might be difficult to achieve.

**Resolution**: Fix the test to not assume that the dataset is in a particular state, don’t hardcode IDs.

#### Random input

**Description**: The test use random values, that sometimes match the expectations, and sometimes not.

**Difficulty to reproduce**: Easy, as the test can be modified to use the “random value” used at the time the test failed

**Resolution**: Once the problem is reproduced, it should be easy to debug and fix the test.


## Test Heuristics

### Why should I care?

Testing can sometimes be reduced to the simplest of checks for a specific behavior of a specific function. We often do this when we're under a time constraint. But is that how our end users always use our software?

By taking just a little extra time in our test approach to think about testing in general, we can save hours of work rolling back a release or producing hotfixes. Here are some simple approaches to enhancing our testing without adding a significant amount of time to our process.

### Discovering Variations
Even simple solutions can have infinite variations to test when we consider the data, timing, environmental or platform factors, configuration, and user behavior following varied sequences actions. We should have as our goal to find the most important and most interesting variations to test, since we cannot possibly test them all.

### Identifying Variables
Some variables are obvious, some are not. Some are accessible to the end user, some are indirectly accessible, modified only indirectly through changing other variables. For example, size or number of files in the filesystem may affect how a feature functions but are outside of the feature itself and may not be directly modified without specific environments or tools.

So our goal here is to identify the variables that may play a part in how a particular feature functions and use these as touch points for testing that feature. Since we may have a number of variables to consider, it would be wise to create simple notes to track those variables to make our testing more effective.

### Heuristics to Help Identify Variables
The definition of a heuristic is varied based on where we look, so we'll use the simple definition: a heuristic is a fallible method for solving a problem or making a decision. They are not algorithms, so they do not always give us the results we want. We should think of them as excellent thinking tools to help us navigate unknowns, such as "did my change introduce a bug?". They are dependent upon context, so not every heuristic is applicable to every problem, just like algorithms.

Here are some heuristics that may help us find variables:
-   Things That Can Be Counted
    -   Zero, One, Many
    -   Too Many
    -   Too Few
-   Relative Position
    -   Beginning, Middle, End
-   Format
-   Input
-   Related to Time
    -   When?
    -   How often?
    -   How long?
-   Location
-   Storage
-   Size
- Depth

### Heuristic Glossary
-   **Boundaries**
	-   Use values that approach the boundary, whether almost too big or small.
	-   Value at the boundary.
- **Count**
	- Zero, One, Many
		- Perform functions on zero, one, and many records.
	 - Too Many
		 - This involves creating conditions that generate more events or objects than the system can handle. Essentially, flooding the system.
	- Too Few
		- This involves creating conditions where fewer data are provided to the system than expected.
- **Depth**
	- Anything that has a hierarchy has depth and can be varied to produce different effects.
		- XML and JSON
		- File Systems
		- Nested Functions
- **Format**
	- Violate or utilize different commonly accepted formats
		- Phone numbers - dashes, periods, parentheses, length, use of country codes
		- Email addresses
		- Domains
		- IP addresses
		- Postal codes
		- Dates
		- Files - document and image file types, variations of a single file type (i.e., PDF)
- **Goldilocks**
	- Vary data to include values that are too big, too small, and just right
- **Position**
	- Beginning, Middle, End
	- Example:
		- Edit strings at the beginning, in the middle, and at the end.
		- Change corresponding items in a list.
- **Sorting**
	- Alphanumeric vs numeric
	- Domain specific sorts (IP address)
	- Sorting with pagination
- **Size**
	- Vary file size, or possibly dimensions in the case of images
	- Variables are often constrained by powers of 2.

### Add Your Own
This is not an exhaustive list of heuristics. If you know others you have found useful, please consider contributing them to this document.

