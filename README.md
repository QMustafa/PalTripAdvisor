# PalTripAdvisor
PalTripAdvisor
*******************************************************************************************************************************************
PalTripAdvisor is a web-service will be used as project for web service oriented course. The main purpose of this project is to prepare a platform for travelers in which they can get information to help them in deciding where to go, weather in the destination country, currency and language used in this country. 
Our service will suggest hotels also in order to offer a package of data to the user. All these service will be done using set of services, and using parallel, sequence and compositions techniques. 
*******************************************************************************************************************************************

Our peoject is attached in the reposotry , but in the future we will add another services. You can download the oml and run the configruation after enter the needed parameters , country, date to-from to  travel and the local currency for your country. 
For now we have dumpy data in our database, maybe in the future we will export data from other respurses and import it to ourdata base so you have the hotel, wehather and currency factor for your destenations. 


If you need a documntation for the APIs we used , you can simply use the below : 

For SOAP APIs: 
you can follow the below links 
Currecny exchange:  http://qutaibamustafa.eastus.cloudapp.azure.com/CurrencyExchange.asmx?op=ExchangeCurrency
Get weather: http://qutaibamustafa.eastus.cloudapp.azure.com/GetWeather.asmx?op=GetWeatherByCity

also in the above links you can find the XML format and WSDL file, SOAP 1.1 and SOAP 1.2 envelops. 


For Rest APIs: 
You can use the below links ( helper ) to check the documntaion for the rest APIs in any format you need XML schema .. ect

getClosestHotel: http://qutaibamustafa.eastus.cloudapp.azure.com/GetClosestHotels.svc/json/help
getPointOfIntrest: http://qutaibamustafa.eastus.cloudapp.azure.com/PointsOfInterest.svc/json/help
