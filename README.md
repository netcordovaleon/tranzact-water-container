# Challenge Water Container Solution

Technologies:
- NetCore 3.1
- Unit Test (Using NUnit)
- Moq

The solution is using Interceptors for get general error (Exceptions) in the application.

Services
```cmd
https://localhost:{PORT}/container/challenge/result
```

Request
```cmd
{
    "CoordinateY" : [1,1]
}
```

Response
```cmd
{
    "Result" : 1
}
```
Recommendation:
Use Postman or SOAP UI for test API's
