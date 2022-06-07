
#1. lock flights during transaction, so other connections can't update while this transaction is active
START TRANSACTION;
	SELECT * FROM flights FOR SHARE;
    SET FOREIGN_KEY_CHECKS=0; -- to disable them
	update flights set departure_airport='ONT' where flight_id = 1546; #this can be a different update
	SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
COMMIT;

#2. lock passangers during transaction, so other transactions don't get a dirty read (cancelled by passenger)
START TRANSACTION;
	select * from passengers;
    SET FOREIGN_KEY_CHECKS=0; -- to disable them
    DELETE FROM passengers WHERE pass_curp = 'ANRO010189MJIARRN7';
    SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
    select * from passengers;
COMMIT;

#3. lock flights during transaction, so other transactions don't get a dirty read (cancelled because of the weather)
START TRANSACTION;
	select * from flights;
	SET FOREIGN_KEY_CHECKS=0; -- to disable them
    DELETE FROM flights where flight_id = 1545;
    SET FOREIGN_KEY_CHECKS=1; -- to re-enable them
    select * from flights;
COMMIT;