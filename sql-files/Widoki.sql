create or replace view Lista_Pracownikow
as select osoby.imie, osoby.nazwisko, pracownicy.wynagrodzenie
from osoby join pracownicy on osoby.idOsoby=pracownicy.idOsoby;

create or replace view Lista_Zamowien
as select osoby.imie, osoby.nazwisko,concat(a1.ulica,' ',a1.nrDomu,'/',ifnull(a1.nrMieszkania,' '),', ',a1.miejscowosc) as miejsceOdbioru, 
concat(a2.ulica,' ',a2.nrDomu,'/',ifnull(a2.nrMieszkania,' '),', ',a2.miejscowosc) as miejsceDoreczenia,zlecenia.terminZlecenia
from osoby 
	join zlecenia on zlecenia.idOsoby = osoby.idOsoby
	join adresy a1 on a1.idAdresu = zlecenia.miejsceOdbioru
	join adresy a2 on a2.idAdresu = zlecenia.miejsceDoreczenia;
	
