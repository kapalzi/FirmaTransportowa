Use Firma_Transportowa;

Create table if not exists Adresy
(
	idAdresu int not null auto_increment primary key,
    ulica varchar(50) not null,
    nrDomu varchar(7) not null,
    nrMieszkania int,
    kodPocztowy varchar(9),
    miejscowosc varchar(25)
);

Create table if not exists Osoby
(
	idOsoby int not null auto_increment primary key,
    idAdresu int references Adresy(idAdresu),
    imie varchar(20) not null,
    nazwisko varchar(30) not null,
    numerTelefonu varchar(12) not null,
    rola varchar(10)
);


Create table if not exists Pracownicy
(
	idPracownika int not null auto_increment primary key,
    idOsoby int references Osoby(idOsoby),
    login varchar(20) not null,
    haslo varchar(30) not null check(length(haslo)>8),
    wynagrodzenie float(6),
    dataZatrudnienia date not null,
    dataZwolenienia datetime 
);

Create table if not exists Pojazdy
(
	idPojazdu int not null auto_increment primary key,
    numerRejestracyjny varchar(10) not null,
    rodzajPojazdu varchar(10) not null,
    markaPojazdu varchar(15) not null,
    modelPojazdu varchar(10) not null,
    sprawnoscPojazdu tinyint(1) not null default '1',
    dostepnoscPojazdu tinyint(1) not null default '1'
);

Create table if not exists Zlecenia
(
	idZlecenia int not null auto_increment primary key,
    idPracownika int references Pracownicy(idPracownika),
    idPojazdu int references Pojazdy(idPojazdu),
    idOsoby int references Osoby(idOsoby),
    miejsceOdbioru int references Adresy(idAdresu),
    miejsceDoreczenia int references Adresy(idAdresu),
    cena float(6) not null,
    dataZamowienia date not null,
    terminZlecenia date not null,
    czyOplacone tinyint(1) not null default '0',
    wagaPaczki float(6) not null,
    stanZamowienia varchar(20) not null default 'Nieoplacone',
    sciezkaDoPlikuFaktury varchar(40) not null,
    user varchar(50)
    
);

Create table if not exists Cennik
(
	cenaZaKm float(6) not null,
    cenaZaKg float(6) not null
);