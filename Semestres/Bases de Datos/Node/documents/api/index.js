const express = require("express");
const app = express();

const configsql = {
    user: 'UserRamen',
    password: 'Ramen123',
    server: 'localhost',
    database: 'ramenreview' ,
    options: {
        trustedConnection: true,
        encrypt: true,
        enableArithAbort: true,
        trustServerCertificate: true
    }
};

app.get('/', function(request, response){
    response.send("API desde NodeJS")
});

app.get('/brand', function(request,response){

    var filter = request.query.filter;

    var sql = require("mssql");

    sql.connect(configsql, function(err){
        if(err) console.log(err);

        var querystring = "";

        if(filter){
            querystring = "select IdBrand, BrandName from Brand where BrandName like '%"+filter+"%'"
        }else{
            querystring = "select IdBrand, BrandName from Brand";
        }

        var result = new sql.Request();

        result.query(querystring, function(err, recordset){
            if(err) console.log(err);
            response.send(recordset);
        })
    })
});

app.get('/topten', function(request, response){
    var idcountry = request.query.idcountry;

    var sql = require("mssql");

    sql.connect(configsql, function(err){
        if(err) console.log(err);

        var sqlrequest = new sql.Request();

        var querystring = '';

        if(idcountry){
            querystring="select top 10 IdRamenReview,CountryName,BrandName,StyleName,Variety,Stars from Ramen rr  join Country c on rr.IdCountry=c.IdCountry join Brand b on rr.IdBrand=b.IdBrand join Style s on rr.IdStyle=s.IdStyle order by Stars desc";
        }else{
            querystring="select top 10 IdRamenReview,CountryName,BrandName,StyleName,Variety,Stars from Ramen rr  join Country c on rr.IdCountry=c.IdCountry join Brand b on rr.IdBrand=b.IdBrand join Style s on rr.IdStyle=s.IdStyle where rr.IdCountry=1 order by Stars desc";
        }

        sqlrequest.query(querystring, function(err, recordset){
            if(err) console.log(err);
            response.send(recordset);
        })
    })
})

app.listen(3000, () => {
    console.log("Servidor iniciado en puerto 3000");
});