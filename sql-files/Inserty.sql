insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Na Ostatnim Groszu','23',null,'54-207','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Gromadzka','11','2','54-007','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Grójecka','17','5','53-118','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Narcyzowa','26','11','53-225','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values (null,'10',null,'54-409','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Hubska','16',null,'50-502','Wrocław');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Chocimska','11','2','00-791','Warszawa');

insert into adresy(ulica,nrDomu,nrMieszkania,kodPocztowy,miejscowosc) 
values ('Jachtowa','37',null,'60-480','Poznań');


insert into osoby(idAdresu,imie,nazwisko,numerTelefonu,rola)
values('1','Jan','Kowalski','000000000','klient');

insert into osoby(idAdresu,imie,nazwisko,numerTelefonu,rola)
values('2','Wojciech','Wątroba','111111111','pracownik');

insert into osoby(idAdresu,imie,nazwisko,numerTelefonu,rola)
values('3','Krzysztof','Kapała','222222222','zarzadca');


insert into pracownicy(idOsoby,login,haslo,wynagrodzenie,dataZatrudnienia)
values('2','pracownik','pracownik','3000',now());

insert into pracownicy(idOsoby,login,haslo,wynagrodzenie,dataZatrudnienia)
values('3','zarzadca','zarzadca','6000',now());


insert into pojazdy(numerRejestracyjny,rodzajPojazdu,markaPojazdu,modelPojazdu)
values('DW 23456','osobowy','Volkswagen','Passat');

insert into pojazdy(numerRejestracyjny,rodzajPojazdu,markaPojazdu,modelPojazdu)
values('DW 98745','tir','Scania','CR');


insert into cennik(cenaZaKm,cenaZaKg) 
values ('0.20','1.0');


insert into zlecenia(idPracownika,idPojazdu,idOsoby,miejsceOdbioru,miejsceDoreczenia,cena,dataZamowienia,terminZlecenia,
czyOplacone,wagaPaczki,sciezkaDoPlikuFaktury)
values ('2','2','1','7','8','450',now(),adddate(now(),7),'0','25','C:\Users\Public');





