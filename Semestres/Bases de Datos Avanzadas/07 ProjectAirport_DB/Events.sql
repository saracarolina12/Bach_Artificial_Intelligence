# 1. borrar vuelos que ya pasaron
	DELIMITER $$
	CREATE EVENT delete_flight_arrived
	ON SCHEDULE
		EVERY 1 DAY 
        starts now() 
        ends '2023-05-06'
	DO 
			delete from flights
			where arrival_datetime < now() - interval 1 year
	DELIMITER ;
	

# 2. cada 24 horas un vuelo nuevo de cierta compañía de aviones
	create event new_flight
	ON SCHEDULE EVERY 24 HOUR
    DO
		INSERT INTO `airport_schema`.`flights`
		(`flight_id`,
		`airline`,
		`departure_datetime`,
		`arrival_datetime`,
		`flight_duration`,
		`flight_distance`,
		`departure_airport`,
		`arrival_airport`)
		VALUES
		((SELECT max(flight_id) FROM flights)+1,'Manhattan Airlines',(select FROM_UNIXTIME(UNIX_TIMESTAMP('2010-04-30 14:53:27') + FLOOR(0 + (RAND() * 63072000)))),(select FROM_UNIXTIME(UNIX_TIMESTAMP('2010-04-30 14:53:27') + FLOOR(0 + (RAND() * 63072000)))),'5:22:00',3058.7,'GDL','MCO');
        
# 3 cada año actualizar la edad del pasajero
	create event update_passanger_age
    ON SCHEDULE EVERY 1 YEAR	
    STARTS '2016-01-01 00:00:00'
	ENDS '2031-01-01 00:00:00'
    do
		update passengers
        set pass_age = pass_age + 1
        



