 
Kauno technologijos universitetas
Informatikos fakultetas
Autokatalogo projektas
	
Autoriaus vardas ir pavadė 
Tautvydas Tunyla IFF-9/6	

	
Priėmė
Doc. prakt. Mažutienė Rasa	

Doc. prakt.  Tamošiūnas Petras	
Ataskaita
 
Turinys
1.	Sistemos paskirtis	3
2.	Funkciniai reikalavimai	4
3.	Sistemos architektūra	5
4.	Naudotojo sąsajos projektas	5
5.	API specifikacija	15
6.	Išvados	20

 

1.	Sistemos paskirtis
Sistemos tikslas bus pateikti informaciją vartotojui, apie tam tikrą automobilio dalį bei jos atitinkamą vietą parodant schemoje kartu su aprašymu. Sistema turės 3 vartotojų tipus: administratorių, svečią ir registruotą vartotoją. Administratorius turės galimybę valdyti visą informacijos srautą internetinėje svetainėje. T.y. jis turės prieigą prie visų CRUD funkcijų. Neregistruotas vartotojas - svečias, puslapyje galės tik matyti pateiktą turinį. Registruotas vartotojas turės galimybę kurti naujus produktus puslapyje t.y: pridėti naujus automobilus, dalis, aprašymus ir schemas.
 

2.	Funkciniai reikalavimai
Sistemos funnkcinai reikalavimai:
•	Vartotojų autentifikacija
•	Vartotojų autorizacija
•	CRUD metodai (automobilių, dalių, schemų ir aprašymų)
•	Dalių, automobilių schemų bei aprašymų sąrašų peržiūra
•	Vartotojo registracija
•	Vartotoj prisijungimas
•	Vartotojo atsijungimas
 

3.	Sistemos architektūra


 
pav. 1. Sistemos architektūra.

4.	Naudotojo sąsajos projektas

Neprisijungusio vartotojo pagrindinis projektuojamos sąsajos langas:

 
pav. 2. Svečio pagrindinis wireframe.
Neprisijungusio vartotojo pagrindinis realizacijos langas:

 
pav. 3. Svečio pagrindinis langas.
Prisijungusio vartotojo pagrindinis projektuojamos sąsajos langas:

 
pav. 4. Vartotjo pagrindinis wireframe.
Prisijungusio vartotojo pagrindinis realizacijos langas:

 
pav. 5. Vartotojo pagrindinis langas.

Registracijos projektuojamos sąsajos langas:

 
pav. 6. Registracijos wireframe.
Registracijos realizacijos langas:

 
pav. 7. Registracijos langas.
Prisijungimo projektuojamos sąsajos langas:

 
pav. 8. Prisijungimo wireframe langas.

Prisijungimo realizacijos langas:

 
pav. 9. Prisijungimo langas.

Administratoriaus matomas objektų projektuojamos sąsajos langas:

 
pav. 10. Administratoriaus objektų wireframe langas.

Administratoriaus matomas objektų realizacijos langas:

 
pav. 11. Administratoriaus matomas objektų realizacijos langas.

Vartotojo matomas elementų projektuojamos sąsajos langas:

 
pav. 12. Vartotojo matomas elementų wireframe langas.

Vartotojo  matomas objektų realizacijos langas:

 
pav. 13. Vartotojo matomas objektų realizacijos langas.

Svečio matomas elementų projektuojamos sąsajos langas:

 

Svečio  matomas objektų realizacijos langas:

 
pav. 14. Svečio matomas objektų realizacijos langas.

Administratoriaus ir vartotojo matomas objektų sukūrimo projektuojamos sąsajos langas:

 
pav. 15. Administratoriaus ir vartotojo matomas objektų pridėjimo wireframe langas.

Administratoriaus ir vartotojo matomas objektų sukūrimo realizacijos langas:

 
pav. 16. Administratoriaus ir vartotojo matomas objektų pridėjimo realizacijos langas.

Administratoriaus matomas objektų atnaujinimo projektuojamos sąsajos langas:

 
pav. 17. Administratoriaus  matomas objektų atnaujinimo wireframe langas.

Administratoriaus matomas objektų atnaujinimo realizacijos langas:

 
pav. 18. Administratoriaus  matomas objektų atnaujinimo realizacijos langas.

Visų vartotojų matomas schemų projektuojamos sąsajos langas:

 
pav. 19. VIsų vartotojų matomas schemų wireframe langas.


Visų vartotojų matomas schemų realizacijos langas:

 
pav. 20. Visų vartotojų matomas schemų realizacijos langas.
5.	API specifikacija

API metodas	Gauti aprašymų sąrašą
Atsako kodai	200 OK
Užklausos pavyzdys	https://localhost:7178/api/Aprasymas
Atsakymo pavyzdys	[
  {
    "id": 0,
    "name": "string",
    "type": "string",
    "description": "string",
    "dalisId": 0
  }
]

API metodas	Įrašyti naują aprašymą
Atsako kodai	201 Created, 400 Bad Request, 403 Forbidden
Užklausos pavyzdys	https://localhost:7178/api/Aprasymas
Atsakymo pavyzdys	{
  "id": 0,
"name": "string",
  "type": "string",
  "description": "string",
  "dalisId": 0
}

API metodas	Gauti aprašymą
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Aprasymas/1
Atsakymo pavyzdys	{
  "id": 0,
  "name": "string",
  "type": "string",
  "description": "string",
  "dalisId": 0
}


API metodas	Atnaujinti aprašymą
Atsako kodai	403 Forbidden, 200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Aprasymas/7
Atsakymo pavyzdys	-

API metodas	Ištrinti aprašymą
Atsako kodai	204 No Content, 404 Not Found, 403 Forbidden
Užklausos pavyzdys	https://localhost:7178/api/Aprasymas/5
Atsakymo pavyzdys	-

API metodas	Prisijungimo
Atsako kodai	200 OK
Užklausos pavyzdys	https://localhost:7178/api/login
Atsakymo pavyzdys	{
  "accessToken": "token"
}

API metodas	Registracijos
Atsako kodai	200 OK, 201 Created
Užklausos pavyzdys	https://localhost:7178/api/register
Atsakymo pavyzdys	{
  "id":"31ac9f71-d5e9-4d52-92db-6ae75372fa7f",
  "userName": "test",
  "email": "test@gmail.com"
}

API metodas	Gauti automobilių sąrašą
Atsako kodai	200 OK
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais
Atsakymo pavyzdys	[
{
    "id": 1019,
    "vin": "ODSNEUN£N3RFF443",
    "model": "Golf Mk3",
    "marke": "VW",
    "production_date":"1992-11-01T00:00:00",
    "userId":"5ef77d50-d4fa-47f4-a6c4-049e028c9ee0",
    "user": null
  }
]

API metodas	Sukurti automobilį
Atsako kodai	201 Created, 400 Bad Request, 403 Forbidden
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais
Atsakymo pavyzdys	{
  "id": 0,
  "vin": "DAADA",
  "model": "test",
  "marke": "test",
  "production_date": "2022-12-21T00:00:00"
}

API metodas	Gauti automobilį
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais/1020
Atsakymo pavyzdys	{
  "id": 1020,
  "vin": "FGFH4443FDSS",
  "model": "Q7",
  "marke": "Audi",
  "production_date":"2020-11-05T00:00:00",
  "userId":"5ef77d50-d4fa-47f4-a6c4-049e028c9ee0",
  "user": null
}

API metodas	Atnaujinti automobilį
Atsako kodai	403 Forbidden, 200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais/1020
Atsakymo pavyzdys	-

API metodas	Ištrinti automobilį
Atsako kodai	204 No Content, 403 Forbidden, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais/1021
Atsakymo pavyzdys	-

API metodas	Gauti specifinio automobilio dalis
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais/1020/Dalys
Atsakymo pavyzdys	[
  {
    "id": 10,
    "name": "Buferis",
    "material": "Plastikas",
    "placement": "Priekis",
    "automobilioId": 1020
  }
]

API metodas	Gauti specifinės automobilio dalies aprašymus
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Automobiliais/1020/
Dalys/10/Aprasymas
Atsakymo pavyzdys	[
  {
    "id": 7,
    "name": "test",
    "type": "test",
    "description": "test",
    "dalisId": 10
  }
]

API metodas	Gauti dalis
Atsako kodai	200 OK
Užklausos pavyzdys	https://localhost:7178/api/Dalys
Atsakymo pavyzdys	[
  {
    "id": 7,
    "name": "Sparnas",
    "material": "Metalas",
    "placement": "Priekis kaire",
    "automobilioId": 1019
  }]

API metodas	Sukurti dalį
Atsako kodai	403 Forbidden, 201 Created, 400 Bad Request
Užklausos pavyzdys	https://localhost:7178/api/Dalys
Atsakymo pavyzdys	{
  "id": 0,
  "name": "test",
  "material": "test",
  "placement": "test",
  "automobilioId": 1022
}

API metodas	Gauti dalį
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Dalys/10
Atsakymo pavyzdys	{
  "id": 10,
  "name": "Buferis",
  "material": "Plastikas",
  "placement": "Priekis",
  "automobilioId": 1020
}

API metodas	Atnaujinti dalį
Atsako kodai	403 Forbidden, 200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Dalys/10
Atsakymo pavyzdys	-

API metodas	Ištrinti dalį
Atsako kodai	204 No Content, 403 Forbidden, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Dalys/5
Atsakymo pavyzdys	-

API metodas	Gauti schemas
Atsako kodai	200 OK
Užklausos pavyzdys	https://localhost:7178/api/Schema
Atsakymo pavyzdys	[
  {
    "id": 5,
    "img": "img-link",
    "aprasymasId": 2
  }
]

API metodas	Sukurti schemą
Atsako kodai	403 Forbidden, 201 Created, 400 Bad Request
Užklausos pavyzdys	https://localhost:7178/api/Schema
Atsakymo pavyzdys	{
  "id": 1,
  "img": "img-link",
  "aprasymasId": 1
}

API metodas	Gauti schemą
Atsako kodai	200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Schema/1
Atsakymo pavyzdys	{
  "id": 1,
  "img": "img-link",
  "aprasymasId": 1
}

API metodas	Atnaujinti schemą
Atsako kodai	403 Forbidden, 200 OK, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Schema/1
Atsakymo pavyzdys	-

API metodas	Ištrinti schemą
Atsako kodai	204 No Content, 403 Forbidden, 404 Not Found
Užklausos pavyzdys	https://localhost:7178/api/Schema/1
Atsakymo pavyzdys	-

6.	Išvados
Projekto vystymo metu pavyko įvykdyti iškeltus reikalavimus puslapiui. Implementuotos veikiančios CRUD funkcijos kurios apima automobilių, dalių, aprašymo ir schemų posistemes. Tai pat puslapyje yra veikianti vartotojo autentifikacija ir autorizacija. Serverio dalis pateikia reikiamus rezultatus į gautas užklausas. Vartotojo sąsaja turi paprastą dizainą ir yra lengvai prieinama ir suprantama vartotojui. Projektas yra funkcionalus ir gali būti lengvai plačiamas.

