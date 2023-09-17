# Flight-Planner-.NET-MAUI
Useful tools for pilots!

Another version of the same project posted here in my repositories, but now making use of C# and more powerful resouces.
The project currently reads, updates and stores favorite locations in a local file, fetches actual weather and forecast, displays sigwx chart
and enhanced radar image (both images retrieved from APIs), and calculates weight and balance limits of a Cessna Citation CJ3 aircraft model 
(small corporate/private jet) - displaying these limits in a line chart (SyncFusion Line Chart). 
It is also possible to check all information about an airport on the "Rotaer" tab. The tab displays a webview consuming a html response from the API.
On the tab "IFR charts", the user can check published charts for a specific airport through search and have all
its resources listed in a listview (procedures, airport map, runaways,...). This tab makes use of a webview as well, calling google
online PDF viewer in order to avoid downloading locally the chart file.
Distance calculator tab fetches latitude and longitude coordinates and calculates the distance between two airports selected by the user,
and displays the distance in nautical miles (aviation patterns).

Further improvements will include WACs (World aeronautical charts), NOTAMs (notice to air men), AIP (aeronautical information publication),
and a Flight Package section which will add to a PDF file all the information that the user wants to store and it will be sent to the user's email.

**UNDER DEVELOPMENT...!**

![splashscreen](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/5882adae-232d-4833-b5b1-78c79e18e360)

![weather_tab](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/7627d6dd-9e6d-4e7d-9938-0137c170d4c2)

![sigwx_popup](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/86cebd73-c1db-4729-acf0-8ae3359ab2f9)

![radar_popup](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/b810ad06-ecdd-4f5b-954b-f6e7b644802a)

![flightplannet02](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/bdeffcbe-9f3a-41f4-9b67-2eabdf74298d)

![rotaer_tab](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/d7f8fe51-7ed4-4303-8f01-94a4786615c0)

![charts_tab](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/d61ed64e-bddd-499e-9d92-337f69127a29)

![wb_tab2](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/93123ee3-f485-4c79-a14e-c79941b61af4)

![wb_tab3](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/df5e294f-3fab-4bc2-9da0-a487e6b7d0db)

![distcalc_tab](https://github.com/fabioweck/Flight-Planner-.NET-MAUI/assets/115494238/24c39e5f-ac5e-498d-8693-38082f3d589f)

