
**Kauno technologijos universitetas**

Informatikos fakultetas

**Autokatalogo projektas**

|||
| :- | :- |
|<p>**Autoriaus vardas ir pavadė** </p><p>Tautvydas Tunyla IFF-9/6</p>|(signature) (date)|
|||
|<p>**Priėmė**</p><p>Doc. prakt. Mažutienė Rasa</p>|(signature) (date)|
|Doc. prakt.  Tamošiūnas Petras||
Ataskaita

**Turinys**

[1.	Sistemos paskirtis	3]

[2.	Funkciniai reikalavimai	4]

[3.	Sistemos architektūra	5]

[4.	Naudotojo sąsajos projektas	5]

[5.	API specifikacija	15]

[6.	Išvados	20]





1. **Sistemos paskirtis**

Sistemos tikslas bus pateikti informaciją vartotojui, apie tam tikrą automobilio dalį bei jos atitinkamą vietą parodant schemoje kartu su aprašymu. Sistema turės 3 vartotojų tipus: administratorių, svečią ir registruotą vartotoją. Administratorius turės galimybę valdyti visą informacijos srautą internetinėje svetainėje. T.y. jis turės prieigą prie visų CRUD funkcijų. Neregistruotas vartotojas - svečias, puslapyje galės tik matyti pateiktą turinį. Registruotas vartotojas turės galimybę kurti naujus produktus puslapyje t.y: pridėti naujus automobilus, dalis, aprašymus ir schemas.



1. **Funkciniai reikalavimai**

Sistemos funnkcinai reikalavimai:

- Vartotojų autentifikacija
- Vartotojų autorizacija
- CRUD metodai (automobilių, dalių, schemų ir aprašymų)
- Dalių, automobilių schemų bei aprašymų sąrašų peržiūra
- Vartotojo registracija
- Vartotoj prisijungimas
- Vartotojo atsijungimas



1. **Sistemos architektūra**



*pav. 1. Sistemos architektūra.*

1. **Naudotojo sąsajos projektas**

Neprisijungusio vartotojo pagrindinis projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224712-6a5dd5a5-f09c-44da-8b79-43b34092fe70.png)

*pav. 2. Svečio pagrindinis wireframe.*

Neprisijungusio vartotojo pagrindinis realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224733-86919288-2f92-4274-b885-98c8378b3c4e.png)

*pav. 3. Svečio pagrindinis langas.*

Prisijungusio vartotojo pagrindinis projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224762-20699ba5-1779-4448-add5-0c993212d3b4.png)

*pav. 4. Vartotjo pagrindinis wireframe.*

Prisijungusio vartotojo pagrindinis realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224786-2d6bc786-1361-43d9-a171-36fad75ffab7.png)

*pav. 5. Vartotojo pagrindinis langas.*

Registracijos projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224796-7a3ef921-3d40-4645-a5c4-0d39c5f74a80.png)

*pav. 6. Registracijos wireframe.*

Registracijos realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224811-8b5dc459-5d2f-4b31-ad61-a4770d1e3ad7.png)

*pav. 7. Registracijos langas.*

Prisijungimo projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224820-2170121a-790a-4f19-ba60-404ae48b35ab.png)

*pav. 8. Prisijungimo wireframe langas.*

Prisijungimo realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224827-33c07f97-804b-4aa7-b92a-dfc9eb685aa9.png)

*pav. 9. Prisijungimo langas.*

Administratoriaus matomas objektų projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224845-101c61c7-f5f2-44a7-b2be-e2a4d2cb4e9b.png)

*pav. 10. Administratoriaus objektų wireframe langas.*

Administratoriaus matomas objektų realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224863-65d5c948-3468-4245-ae56-749a4739ca0f.png)

*pav. 11. Administratoriaus matomas objektų realizacijos langas.*

Vartotojo matomas elementų projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209224883-6f9c8ee0-36e7-4f15-9daf-d8180a3c7e00.png)

*pav. 12. Vartotojo matomas elementų wireframe langas.*

Vartotojo  matomas objektų realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209224900-915dd9d0-84d3-4c6e-9a51-4414e7222a20.png)

*pav. 13. Vartotojo matomas objektų realizacijos langas.*

Svečio matomas elementų projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209225375-b8333adb-14d6-418d-b4f5-233f128cec31.png)

*pav. 14. Vartotojo matomas objektų wireframe langas.*

Svečio  matomas objektų realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209225390-470f298a-5aff-4b0b-81c7-e23cc4657b23.png)

*pav. 15. Svečio matomas objektų realizacijos langas.*

Administratoriaus ir vartotojo matomas objektų sukūrimo projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209225404-80926fad-76d1-40b5-9373-b98fcc35f768.png)

*pav. 16. Administratoriaus ir vartotojo matomas objektų pridėjimo wireframe langas.*

Administratoriaus ir vartotojo matomas objektų sukūrimo realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209225415-88d53f02-29ed-4046-9cba-18de57670414.png)

*pav. 17. Administratoriaus ir vartotojo matomas objektų pridėjimo realizacijos langas.*

Administratoriaus matomas objektų atnaujinimo projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209225430-497a5ded-2f80-48f9-99e8-41fce32bcf23.png)

*pav. 18. Administratoriaus  matomas objektų atnaujinimo wireframe langas.*

Administratoriaus matomas objektų atnaujinimo realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209225444-f78254c6-dc3b-45a8-905d-403660234839.png)

*pav. 19. Administratoriaus  matomas objektų atnaujinimo realizacijos langas.*

Visų vartotojų matomas schemų projektuojamos sąsajos langas:

![image](https://user-images.githubusercontent.com/79149026/209225455-6f591d46-ec57-4eb8-8e07-abadee18350a.png)

*pav. 20. VIsų vartotojų matomas schemų wireframe langas.*


Visų vartotojų matomas schemų realizacijos langas:

![image](https://user-images.githubusercontent.com/79149026/209225475-c10b0549-25a6-4557-b857-9d9fdc509633.png)

*pav. 21. Visų vartotojų matomas schemų realizacijos langas.*

1. **API specifikacija**


|**API metodas**|Gauti aprašymų sąrašą|
| - | - |
|**Atsako kodai**|200 OK|
|**Užklausos pavyzdys**|https://localhost:7178/api/Aprasymas|
|**Atsakymo pavyzdys**|<p>[</p><p>`  `{</p><p>`    `"id": 0,</p><p>`    `"name": "string",</p><p>`    `"type": "string",</p><p>`    `"description": "string",</p><p>`    `"dalisId": 0</p><p>`  `}</p><p>]</p>|


|**API metodas**|Įrašyti naują aprašymą|
| - | - |
|**Atsako kodai**|201 Created, 400 Bad Request, 403 Forbidden|
|**Užklausos pavyzdys**|https://localhost:7178/api/Aprasymas|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 0,</p><p>"name": "string",</p><p>`  `"type": "string",</p><p>`  `"description": "string",</p><p>`  `"dalisId": 0</p><p>}</p>|


|**API metodas**|Gauti aprašymą|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Aprasymas/1|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 0,</p><p>`  `"name": "string",</p><p>`  `"type": "string",</p><p>`  `"description": "string",</p><p>`  `"dalisId": 0</p><p>}</p><p></p>|


|**API metodas**|Atnaujinti aprašymą|
| - | - |
|**Atsako kodai**|403 Forbidden, 200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Aprasymas/7|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Ištrinti aprašymą|
| - | - |
|**Atsako kodai**|204 No Content, 404 Not Found, 403 Forbidden|
|**Užklausos pavyzdys**|https://localhost:7178/api/Aprasymas/5|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Prisijungimo|
| - | - |
|**Atsako kodai**|200 OK|
|**Užklausos pavyzdys**|https://localhost:7178/api/login|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"accessToken": "token"</p><p>}</p>|


|**API metodas**|Registracijos|
| - | - |
|**Atsako kodai**|200 OK, 201 Created|
|**Užklausos pavyzdys**|https://localhost:7178/api/register|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id":"31ac9f71-d5e9-4d52-92db-6ae75372fa7f",</p><p>`  `"userName": "test",</p><p>`  `"email": "test@gmail.com"</p><p>}</p>|


|**API metodas**|Gauti automobilių sąrašą|
| - | - |
|**Atsako kodai**|200 OK|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais|
|**Atsakymo pavyzdys**|<p>[</p><p>{</p><p>`    `"id": 1019,</p><p>`    `"vin": "ODSNEUN£N3RFF443",</p><p>`    `"model": "Golf Mk3",</p><p>`    `"marke": "VW",</p><p>`    `"production\_date":"1992-11-01T00:00:00",</p><p>`    `"userId":"5ef77d50-d4fa-47f4-a6c4-049e028c9ee0",</p><p>`    `"user": null</p><p>`  `}</p><p>]</p>|


|**API metodas**|Sukurti automobilį|
| - | - |
|**Atsako kodai**|201 Created, 400 Bad Request, 403 Forbidden|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 0,</p><p>`  `"vin": "DAADA",</p><p>`  `"model": "test",</p><p>`  `"marke": "test",</p><p>`  `"production\_date": "2022-12-21T00:00:00"</p><p>}</p>|


|**API metodas**|Gauti automobilį|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais/1020|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 1020,</p><p>`  `"vin": "FGFH4443FDSS",</p><p>`  `"model": "Q7",</p><p>`  `"marke": "Audi",</p><p>`  `"production\_date":"2020-11-05T00:00:00",</p><p>`  `"userId":"5ef77d50-d4fa-47f4-a6c4-049e028c9ee0",</p><p>`  `"user": null</p><p>}</p>|


|**API metodas**|Atnaujinti automobilį|
| - | - |
|**Atsako kodai**|403 Forbidden, 200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais/1020|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Ištrinti automobilį|
| - | - |
|**Atsako kodai**|204 No Content, 403 Forbidden, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais/1021|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Gauti specifinio automobilio dalis|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Automobiliais/1020/Dalys|
|**Atsakymo pavyzdys**|<p>[</p><p>`  `{</p><p>`    `"id": 10,</p><p>`    `"name": "Buferis",</p><p>`    `"material": "Plastikas",</p><p>`    `"placement": "Priekis",</p><p>`    `"automobilioId": 1020</p><p>`  `}</p><p>]</p>|


|**API metodas**|Gauti specifinės automobilio dalies aprašymus|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|<p><https://localhost:7178/api/Automobiliais/1020/></p><p>Dalys/10/Aprasymas</p>|
|**Atsakymo pavyzdys**|<p>[</p><p>`  `{</p><p>`    `"id": 7,</p><p>`    `"name": "test",</p><p>`    `"type": "test",</p><p>`    `"description": "test",</p><p>`    `"dalisId": 10</p><p>`  `}</p><p>]</p>|


|**API metodas**|Gauti dalis|
| - | - |
|**Atsako kodai**|200 OK|
|**Užklausos pavyzdys**|https://localhost:7178/api/Dalys|
|**Atsakymo pavyzdys**|<p>[</p><p>`  `{</p><p>`    `"id": 7,</p><p>`    `"name": "Sparnas",</p><p>`    `"material": "Metalas",</p><p>`    `"placement": "Priekis kaire",</p><p>`    `"automobilioId": 1019</p><p>`  `}]</p>|


|**API metodas**|Sukurti dalį|
| - | - |
|**Atsako kodai**|403 Forbidden, 201 Created, 400 Bad Request|
|**Užklausos pavyzdys**|https://localhost:7178/api/Dalys|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 0,</p><p>`  `"name": "test",</p><p>`  `"material": "test",</p><p>`  `"placement": "test",</p><p>`  `"automobilioId": 1022</p><p>}</p>|


|**API metodas**|Gauti dalį|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Dalys/10|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 10,</p><p>`  `"name": "Buferis",</p><p>`  `"material": "Plastikas",</p><p>`  `"placement": "Priekis",</p><p>`  `"automobilioId": 1020</p><p>}</p>|


|**API metodas**|Atnaujinti dalį|
| - | - |
|**Atsako kodai**|403 Forbidden, 200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Dalys/10|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Ištrinti dalį|
| - | - |
|**Atsako kodai**|204 No Content, 403 Forbidden, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Dalys/5|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Gauti schemas|
| - | - |
|**Atsako kodai**|200 OK|
|**Užklausos pavyzdys**|https://localhost:7178/api/Schema|
|**Atsakymo pavyzdys**|<p>[</p><p>`  `{</p><p>`    `"id": 5,</p><p>`    `"img": "img-link",</p><p>`    `"aprasymasId": 2</p><p>`  `}</p><p>]</p>|


|**API metodas**|Sukurti schemą|
| - | - |
|**Atsako kodai**|403 Forbidden, 201 Created, 400 Bad Request|
|**Užklausos pavyzdys**|https://localhost:7178/api/Schema|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 1,</p><p>`  `"img": "img-link",</p><p>`  `"aprasymasId": 1</p><p>}</p>|


|**API metodas**|Gauti schemą|
| - | - |
|**Atsako kodai**|200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Schema/1|
|**Atsakymo pavyzdys**|<p>{</p><p>`  `"id": 1,</p><p>`  `"img": "img-link",</p><p>`  `"aprasymasId": 1</p><p>}</p>|


|**API metodas**|Atnaujinti schemą|
| - | - |
|**Atsako kodai**|403 Forbidden, 200 OK, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Schema/1|
|**Atsakymo pavyzdys**|-|


|**API metodas**|Ištrinti schemą|
| - | - |
|**Atsako kodai**|204 No Content, 403 Forbidden, 404 Not Found|
|**Užklausos pavyzdys**|https://localhost:7178/api/Schema/1|
|**Atsakymo pavyzdys**|-|

1. **Išvados**

Projekto vystymo metu pavyko įvykdyti iškeltus reikalavimus puslapiui. Implementuotos veikiančios CRUD funkcijos kurios apima automobilių, dalių, aprašymo ir schemų posistemes. Tai pat puslapyje yra veikianti vartotojo autentifikacija ir autorizacija. Serverio dalis pateikia reikiamus rezultatus į gautas užklausas. Vartotojo sąsaja turi paprastą dizainą ir yra lengvai prieinama ir suprantama vartotojui. Projektas yra funkcionalus ir gali būti lengvai plačiamas.

