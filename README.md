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

2 - In your Cosmos Emulator create a Databse ProgramApp and container Program
    
3 - Replace the connection string into launchSettings.json

```bash
    "CosmosDBAccountUri": "https://localhost:8081/",
    "CosmosDBAccountPrimaryKey": "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
    "CosmosDbName": "ProgramApp",
    "CosmosDbContainerName": "Program",
    "CosmosAppDbContainerName": "Applications"
```

4 - Rebuild the solution and then run it. It should open the swagger and you are ready to test.
## API Reference

#### Create an Application Form

```http
  POST https://localhost:7177/api/CreateApp
```

```json
{
   "id":"string",
   "programId":"string",
   "programTitle":"string",
   "programDescription":"string",
   "questionfields":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true,
         "internal":true,
         "hide":true
      }
   ],
   "additionalQuestionfield":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true
      }
   ]
}
```

#### Update the Application Form

```http
  PUT https://localhost:7177/api/UpdateApp
```

```json
{
   "id":"string",
   "programId":"string",
   "programTitle":"string",
   "programDescription":"string",
   "questionfields":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true,
         "internal":true,
         "hide":true
      }
   ],
   "additionalQuestionfield":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true
      }
   ]
}
```

#### Get the Application Form

```http
  GET https://localhost:7177/GetApp
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Enter the id of the form to retrive it.  |

#### Submit the Application Form

```http
  POST https://localhost:7177/SubmitApp
```


```json
{
   "id":"string",
   "programId":"string",
   "programTitle":"string",
   "programDescription":"string",
   "questionfields":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true,
         "internal":true,
         "hide":true
      }
   ],
   "additionalQuestionfield":[
      {
         "fieldId":"string",
         "fieldTitle":"string",
         "fieldValue":"string",
         "fieldType":"string",
         "options":[
            "string"
         ],
         "required":true
      }
   ]
}
```

## Author

- Mehul Panchal