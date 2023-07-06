Welcome to the Scraping Population Data Project 

For this Project I am using in Backend in Dot net core Api and Frontend I am using React js also Database uses Sqlite. 

Dot net core Api: In Dot Net Core Api I use 3 layers of Architecture. Data Entity Layer(we add Model hare and Write Off the code which is a direct Connect of Sqlite) Business Logic Layer( This layer I use for writing all the Logic Code. This layer is Connected of DEL) And Last is Controller layer(This layer Write All Api Code which is Connected to BLL). 

1. First Api Show All the lists which are stored are Database.
2. second API use For "Scraping". This API is used for Wikipedia data used for "Scraping". First, catch all the data from Wikipedia then this data is stored in the Database. 
3. third Api use for "pagination ". Some limited data are showing use for "Pagination";


Fronted: Frontened is used for React js. first, fetch the API data and make the data table and show the "Pagination" Data. After making the Pie chart use of Pagination Data use for "victory-pie". 

Sqlite: Use for store of Data 