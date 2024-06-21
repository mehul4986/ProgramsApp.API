# Programs and Application APIs

I've developed the Programs and Application APIs as part of my assessment. 


This assessment has a ProgramsApp.API solution consisting of 4 APIs.


1 - Create Application Form : This API will create the application form.

2 - Update Application Form : This API will update the application form.

3 - Get Application Form : This API will Get the application form.

4 - Submit Application Form : This API will Submit the application form.


## Tech Stack

**Framework** .NET 8

**Programming Language** C# 10

**Database Server:** Cosmos DB Emulator

**IDE:** Visual Studio 2022 Community Edition


## Installation

1 - Clone the solution on your machine and then build the solution.

2 - In your Cosmos Emulator create a Databse and container
    
3 - Replace the connection string into launchSettings.json

```bash
  "ExchangeRateConnStr": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CurrencyManager;Integrated Security=True;Integrated Security=SSPI;",
```

4 - Rebuild the solution and then run it. It should open the swagger and you are ready to test.
## API Reference

#### Create an Application Form

```http
  POST https://localhost:7177/CreateApp
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `basecode` | `string` | **Required**. Base Currency Code, from which you want to exchange |
| `targetcode` | `string` | **Required**. Target Currency Code,to which you want to exchange |
| `amount` | `decimal` | **Required**. Amount that you want to convert |

#### Update the Application Form

```http
  PUT https://localhost:7177/UpdateApp
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `FromDate`      | `Date` | **Optional**. From which date you want to retrieve the conversion history.  |

#### Get the Application Form

```http
  GET https://localhost:7177/GetApp
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `FromDate`      | `Date` | **Optional**. From which date you want to retrieve the conversion API history.  |

#### Submit the Application Form

```http
  POST https://localhost:7177/SubmitApp
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `basecode` | `string` | **Required**. Base Currency Code, from which you want to exchange |
| `targetcode` | `string` | **Required**. Target Currency Code,to which you want to exchange |
| `amount` | `decimal` | **Required**. Amount that you want to convert |

## Author

- Mehul Panchal