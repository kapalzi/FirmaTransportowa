create user if not exists 'klient'@'localhost' default role klient;

create user if not exists 'pracownik'@'localhost' identified by 'pracownik' default role pracownik;

create user if not exists 'zarzadca'@'localhost' identified by 'zarzadca' default role zarzadca;