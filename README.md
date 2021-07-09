# Weather.API
a REST API service to provide weather  information using ASP.NET framework
The Weather.API will expose several "read" , "write actions as HTTP methods. Each action will correspond to a method in the WeatherController class.

Get() 
The method name starts with "Get", so by convention it maps to GET requests. Also, because the method has no parameters,
 it maps to a URI that does not contain an "id" segment in the path.
 
  public WeatherData GetWeather(int id)
 This method name also starts with "Get", but the method has a parameter named id. This parameter is mapped to the "id" segment of the URI path. 
 The ASP.NET Web API framework automatically converts the ID to the correct data type (int) for the parameter.

 The Get() method throws an exception of type HttpResponseException if id is not valid. 
 This exception will be translated by the framework into a 404 (Not Found) error.
 
 public WeatherData GetWeatherDataByLocation(Location location)
 If the request URI has a query string, Web API tries to match the query parameters to parameters on the controller method. 
 Therefore, a URI of the form "api/weathers?location=: {
 "lat":36.1189,
 "lon”: -86.6892,
 "city":"Palo Alto",
 "state":"California"
 }" will map to this method.
 
public HttpResponseMessage Post(WeatherData newWeather)
  
The method return type is now HttpResponseMessage. By returning an HttpResponseMessage instead of a WeatherData, we can control the details of the HTTP response message,
including the status code and the Location header.

The CreateResponse method creates an HttpResponseMessage and automatically writes a serialized representation of the Product object into the body fo the response message.

public void Put(int id, WeatherData weather)

The method name starts with "Put...", so Web API matches it to PUT requests. The method takes two parameters, the Weather ID and the updated weather.
The id parameter is taken from the URI path, and the weather parameter is deserialized from the request body. 
By default, the ASP.NET Web API framework takes simple parameter types from the route and complex types from the request body.

public void Delete(int id)

If a DELETE request succeeds, it can return status 200 (OK) with an entity-body that describes the status; status 202 (Accepted) if the deletion is still pending;
or status 204 (No Content) with no entity body. In this case, the DeleteWeather method has a void return type, so ASP.NET Web API automatically translates
this into status code 204 (No Content).
