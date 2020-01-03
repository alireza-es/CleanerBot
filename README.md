# CleanerBot
[![Build Status](https://www.travis-ci.com/alireza-es/CleanerBot.svg?branch=master)](https://www.travis-ci.com/alireza-es/CleanerBot) [![CircleCI](https://circleci.com/gh/alireza-es/CleanerBot.svg?style=svg)](https://circleci.com/gh/alireza-es/CleanerBot) [![Build Status](https://dev.azure.com/alireza-es/CleanerBot/_apis/build/status/CleanerBot-.Net%20Core-CI?branchName=master)](https://dev.azure.com/alireza-es/CleanerBot/_build/latest?definitionId=6&branchName=master) [![test results](https://img.shields.io/azure-devops/tests/alireza-es/CleanerBot/6)](https://dev.azure.com/alireza-es/CleanerBot/_build?definitionId=6)




# Background
When we have a lot of people working in an office it can get dirty quite quickly if you're not careful.
However, the cleaning staff is expensive. To save money on cleaning staff the best solution was deemed to be the creation of an automatic cleaning robot that cleans the office at night.
This is a prototype of this robot which is created in Test Driven Development (TDD).

# Solution
In this solution, our focus is on simplicity and we have these classes to implement the prototype:

## Robot
The main class represents the attributes and behaviors of the Robot. We have a constructor to force the client if he wants to instantiate an object he has to specify it's location. So the CurrentLocation is the main attribute of the Robot. 
The Robot has two behaviors:
- **Move()**: Move in a specific direction with specific steps
- **GetCleanedLocations**(): Calculate the unique places robot has visited

We use **`HashSet<T>`** to keep track of locations that have been cleaned. For using `HashSet` we implement `GetHashCode` of Point class as bellow:
```csharp
        public override int GetHashCode()
        {
            return $"{X}-{Y}".GetHashCode();
        }
```
## Point
It's a Value Object to encapsulate the coordinates in a specific class. This Value Object is composed of two attributes: **X, Y**. If we changed one of these attributes it would a new point object! So we force the client to set (X, Y) in its constructor and the client is not allowed to change x and y. There just have two public get for X and Y.
Because Point is showing coordinates, we can say that if two point objects have the same X and Y, they are equal. So we implement **`IEquatable<T>`** in this class as bellow code:
```csharp
    public class Point : IEquatable<Point>
    {
        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }
    }
```
furthermore, the Point value object has a method called `GetNeighborLocation` that returns its neighbor location to use in Robot. It returns a new Point because it is a new Point with different coordinates.

# Development Approach
## Test-Driven Development
Our approach to development is **TDD (Test-Driven Development)**. We use the **Test-First** method in design and implementation. 
There are two types of tests in our solution:
- **Integration Tests:** INTEGRATION TESTING is a high level of software testing where individual units are combined and tested as a group. Here, all integration test classes are inherited from the `IntegrationBaseTest` class. In the constructor of this class, a new instance of `ProcessStartInfo` is created which runs the UI console app using the `dotnet` process. We use the `Process.StandardInput` to send parameters to the process and the `Process.StandardOutput` to get and check it's output.
- **Unit Tests:** UNIT TESTING is a low level of software testing where individual units/ components of the software are tested. The purpose is to validate that each unit of the software performs as designed. A unit is the smallest testable part of any software. It usually has one or a few inputs and usually a single output. Here, each member of our solution has its related unit tests and our approach is covering all code lines and code blocks.
<img src="https://github.com/alireza-es/CleanerBot/blob/master/docs/images/CodeCoverage.JPG"/>

### Test Framework

We use **`XUnit`** framework to write unit tests. `xUnit.net` is a free, open-source, community-focused unit testing tool for the .NET Framework.
### Naming Convension
In unit test methods we are using **`MethodName_StateUnderTest_ExpectedBehavior`** naming standard. following are some of examples:

- `Equals_WhenTwoDifferentObjectsHaveTheSameCoordinates_ObjectsAreEqual`
- `Move_WithOneCommand_TwoPointsMustBeCleaned`
- `GetNeighborLocation_WithValidInput_GetValidResult`
- `GetNeighborLocation_WithInValidInput_ThrowArgumentOutOfRangeException`

## Continous Integration
Continuous Integration (CI) involves producing a clean build of the system several times per day, usually with a tool like TravisCI, Azure DevOps, etc. Agile teams typically configure CI to include automated compilation, unit test execution, and source control integration. 
Here, We use three different **CI/CD** services to run the continuous integration of our solution. When any changeset pushes on GitHub our build in three CI servers start to run and the result of the last build is shown on the top of this page in related build badges. Our selected CI servers are:
- [**Microsoft Azure DevOps**](https://dev.azure.com/alireza-es/CleanerBot/_build/latest?definitionId=6&branchName=master)
- [**TravisCI** ](https://www.travis-ci.com/alireza-es/CleanerBot)
- [**CicleCi**](https://circleci.com/gh/alireza-es/CleanerBot)
<p align="center">
<img src="https://alireza-es.github.io/CleanerBot/docs/ci/azuredevops.png" width="90px"/>
<img src="https://alireza-es.github.io/CleanerBot/docs/ci/circleci.png" width="90px"/>
<img src="https://alireza-es.github.io/CleanerBot/docs/ci/travisci.png" width="90px"/>
</p>


