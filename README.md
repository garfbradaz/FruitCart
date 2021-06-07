[![.NET Build and Test](https://github.com/garfbradaz/FruitCart/actions/workflows/dotnet.yml/badge.svg)](https://github.com/garfbradaz/FruitCart/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/garfbradaz/FruitCart/badge.svg?branch=main)](https://coveralls.io/github/garfbradaz/FruitCart?branch=main)

# FruitCart

Simple Checkout system for Apples and Oranges, built using .NET 5. This application was built using _Visual Studio Code_ but has also been tested within _Visual Studio 2019 Community_.

## Pre-Requisitites

So the following is needed on your machine to run and test the application:

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

* IDE of your choice that supports C# and ASP.NET Core. *Note*, as mentioned previously I have only tested in _Visual Studio Code_ and _Visual Studio 2019 Community_.

* [Postman](https://www.postman.com/downloads/) - Also be aware you will need a Postman account (free). Ive used Postman for testing the API endpoint itself.

## Visual Studio Code - Experience

Just a shout out for my favourite editor, I've included some **recommended extensions** to install which are set in the `extensions.json` file with the repository. These should give you:

* C# Compiler with Omnisharp
* Solution Explorer for `.sln`
* .NET Test Explorer
* Gitlens

So if you are not comfortable with VSCode this should give a similiar experience you might be comfortable with if you are a Visual Studio veteran.

## Visual Studio Code - Debugging

The `launch.json` has everything you need to launch the API project. Once started you should be able to git the Swagger page:

> https://localhost:5001/swagger/index.html

# Client

Currently for Step 1 & Step 2 I'm only using **Postman** to test it is working (obviously I have unit and integration tests).

I have included 2 postman files within the root of the project in a `.\postman` folder. This includes:

* Postman collection, with some Premade requests for the `PlaceOrderRequest` and a collection of `Fruits`. These have some tests in them as well to test the `PlaceOrderResponse` and the total cost.

* Postman environment variables for Local Dev

You will need to [**import**](https://learning.postman.com/docs/getting-started/importing-and-exporting-data/) these into Postman to use. 

# Architecture

API project that uses a lightweight **CQRS** pattern using [vertical slicing](https://jimmybogard.com/vertical-slice-architecture/) for the feature folders. This will come into its own when You have more `Action.Features`, example `Query.GetFruits` allowing you to isolate your features, domain models, CQRS DTOs etc.

At the moment there are two core Handlers `CalculateTotalOrderWithoutDeals` (Step 1) and `CalculateTotalOrderWithDeals` (Step 2) that handle the core business logic of the domain.

## TODO but not enough time

I will be doing a _Step 3_ which I hope to have done _if_ I get to the next round
* The Value Objects are not proper DDD Value Objects, they are missing the `IEquatable` implementation within a Base Class OR use the new C# 9.0 `record` feature.

* I wanted to create a simple Blazor UI for the Point of Sale System, so you dont have to use Postman each time you want to test it, inlcuding the `Query.GetFruits` feature for obtaining fruits.

* Maybe a persistence layer, and incorporate that. At the moment there are some hacky default Costs for the fruits within the Factories that dont sit well with me.

* If a persistence layer existed, then I would add a `DOCKERFILE` and `docker-compose.yml` to allow you to run locally without needing to install anything.