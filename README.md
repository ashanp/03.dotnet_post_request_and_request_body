This example shows the details of how to post a custom header. to submit custom headers to the server, we need to use Postman. 

Get - used to retrive data from the servers, the data is appended to the URL. So in the URL we see the data and we called them query string parameters

  <img width="805" alt="image" src="https://github.com/user-attachments/assets/d5f101f0-a633-4ca3-bf36-9c0fd1d73662">

POST, PUT, PATCH, DELETE - used to manupilate data in database by sending data to the server. 
this data will go in the message body, not in the header, seperated from the URL. 
the data can be sent as URL encoded data or in jsom formated. in html forms, the default is URL encoded. 

  <img width="805" alt="image" src="https://github.com/user-attachments/assets/cf1d7103-28de-4339-bb61-a0bff946fce6">


We can send some body data by using postman -> body tab to submit some data. dont forget to change the request type to POST. 

once you submit, Postman will submit data to the server and the server will resive the data. but we have to make changes in the server side to recieve the data.
In postman once we post data, they will come as HttpRequestStream. 

String requestBodyString;
using(StreamReader reader = new StreamReader(context.Request.Body)){
    requestBodyString = await reader.ReadToEndAsync();
    await context.Response.WriteAsync($"<div> the body is : {requestBodyString} </div>");
}



