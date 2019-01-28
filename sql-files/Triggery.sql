delimiter $$
Create trigger Trigger_wRealizacji before update on zlecenia
for each row
begin
	if new.czyOplacone = '1' then
	set new.stanZamowienia = 'W realizacji';
    end if;
end;
$$
delimiter ;