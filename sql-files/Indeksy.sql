create index osoba
on osoby(nazwisko, imie);

create index dataZamowienia
on zlecenia(dataZamowienia);

create unique index numerTelefonu
on osoby(numerTelefonu);

create unique index numerRejestracyjny
on pojazdy(numerRejestracyjny);

create unique index login
on pracownicy(login);

