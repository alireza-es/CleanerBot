# CleanerBot
[![Build Status](https://www.travis-ci.com/alireza-es/CleanerBot.svg?branch=master)](https://www.travis-ci.com/alireza-es/CleanerBot) [![CircleCI](https://circleci.com/gh/alireza-es/CleanerBot.svg?style=svg)](https://circleci.com/gh/alireza-es/CleanerBot) [![Build Status](https://dev.azure.com/alireza-es/CleanerBot/_apis/build/status/CleanerBot-.Net%20Core-CI?branchName=master)](https://dev.azure.com/alireza-es/CleanerBot/_build/latest?definitionId=6&branchName=master) [![test results](https://img.shields.io/azure-devops/tests/alireza-es/CleanerBot/6)](https://dev.azure.com/alireza-es/CleanerBot/_build?definitionId=6)




# Background
When we have a lot of people working in an office it can get dirty quite quickly if you're not careful.
However, cleaning staff are expensive. To save money on cleaning staff the best solution was deemed to be the creation of an automatic cleaning robot that cleans the office at night.
This is a prototype of this robot which is created in Test Drivent Development (TDD).

# Solution
In this solution, our focus is on simpilicity and we have these classes to implement the prototype:

## Robot
The main class represents the attributes and behaviors of the Robot. We have a constructor to force the client if he wants to instantiate an object he has to specify it's location. So the CurrentLocation is the main attribute of the Robot. 
The Robot has two behaviors:
- **Move()**: Move in a specific direction with specific steps
- **GetCleanedLocations**(): Calculate the unique places robot has visited

We use **`HashSet<T>`** to keep track of locations that has been cleaned. For using `HashSet` we implement `GetHashCode` of Point class as bellow:
```csharp
        public override int GetHashCode()
        {
            return $"{X}-{Y}".GetHashCode();
        }
```
## Point
It's a Value Object to encapsulate  the coordinates in a specific class. This Value Object is composed of two attributes: **X, Y**. If we changed one of these attributes it would a new point object! So we force the client to set (X, Y) in its constructor and the client is not allowed to change x and y. There just have two public get for X and Y.
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
# Development Approach
Our approach to development is **TDD (Test-Driven Development)**. We use the **Test-First** method in design and implementation. We use three different **CI/CD** services to run continuous integration of our solution. When any changeset pushes on GitHub our build in three CI servers start to run and the result of the last build is shown on the top of this page in related build badges. Our selected CI servers are **Microsoft Azure DevOps**, **TravisCI** and **CicleCi**.