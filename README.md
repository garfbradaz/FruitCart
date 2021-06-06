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

Currently for Step 1 I'm only using **Postman** to test it is working (obviously I have unit and integration tests).

I have included 2 postman files within the root of the project in a `.\postman` folder. This includes:

* Postman collection, with some Premade requests for the `PlaceOrderRequest` and a collection of `Fruits`. These have some tests in them as well to test the `PlaceOrderResponse` and the total cost.

* Postman environment variables for Local Dev

You will need to [**import**](https://learning.postman.com/docs/getting-started/importing-and-exporting-data/) these into Postman to use. 