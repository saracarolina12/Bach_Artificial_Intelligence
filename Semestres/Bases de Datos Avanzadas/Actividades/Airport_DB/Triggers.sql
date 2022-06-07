#1. se cancela vuelo por mal clima
	DELIMITER $$
	CREATE TRIGGER cancelled_flight_weather
		AFTER DELETE ON flights
		FOR EACH ROW
		BEGIN
			DELETE FROM tickets
			WHERE ticket_flight_id = old.flight_id;
		END$$
	DELIMITER ;

	SET FOREIGN_KEY_CHECKS=0; -- to disable them
	DELETE FROM flights WHERE flight_id = 1541;
	SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
#--------------------------------------------------------#
#2. pasajero cancela su vuelo
	DELIMITER $$
	CREATE TRIGGER passanger_cancelled_flight
		AFTER DELETE ON tickets
		FOR EACH ROW
		BEGIN
			DELETE FROM passengers
			WHERE pass_curp = old.ticket_curp;
		END$$
	DELIMITER ;
    
    SET FOREIGN_KEY_CHECKS=0; -- to disable them
	DELETE FROM tickets WHERE ticket_curp = 'FALU041100HAGKLLQ1';
	SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
#--------------------------------------------------------#
#3. Cierra un aeropuerto por quiebra
	DELIMITER $$
	CREATE TRIGGER airport_bankruptcy
		AFTER DELETE ON airports
		FOR EACH ROW
		BEGIN
			DELETE FROM flights
			WHERE departure_airport = old.iata_code;
            DELETE FROM tickets
            WHERE ticket_iata = old.iata_code;
		END$$
	DELIMITER ;

    SET FOREIGN_KEY_CHECKS=0; -- to disable them
	DELETE FROM airports WHERE iata_code = 'AGU';
	SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
    
    select * from airports;
	select * from flights;
	select * from tickets;
	select * from passengers;
	
