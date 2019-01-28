update zlecenia 
set czyOplacone = 1 where idZlecenia = 7;

drop trigger Trigger_wRealizacji;

delete from zlecenia where idZlecenia = 6;