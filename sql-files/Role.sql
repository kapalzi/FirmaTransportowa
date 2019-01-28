create role 'klient','pracownik','zarzadca';

grant insert,select,update,delete on zlecenia
to klient;

grant insert,update, select on adresy
to klient;

grant select on cennik 
to klient;

grant insert,update, select on osoby
to klient;

grant insert,select,update,delete on pojazdy
to pracownik;

grant insert,select,update,delete on zlecenia
to pracownik;

grant select on adresy
to pracownik;

grant select,update on cennik
to pracownik;

grant select,update,delete on lista_zamowien
to pracownik;

grant all on pracownicy 
to zarzadca;

grant all on pojazdy
to zarzadca;

grant all on zlecenia 
to zarzadca;

grant all on adresy
to zarzadca;

grant all on cennik 
to zarzadca;

grant all on lista_zamowien
to zarzadca;

grant all on lista_pracownikow
to zarzadca;

