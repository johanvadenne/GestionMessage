DROP TRIGGER Trig_INSERT_T_TypeMessage;
DROP TRIGGER Trig_UPDATE_T_TypeMessage;
DROP TRIGGER Trig_DELETE_T_TypeMessage;

-- Création du trigger
CREATE TRIGGER Trig_INSERT_T_TypeMessage
AFTER INSERT ON T_TypeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_TypeMessage', new.IdTypeMessage,datetime('now'),'INSERT');
END;

-- Création du trigger
CREATE TRIGGER Trig_UPDATE_T_TypeMessage
AFTER UPDATE ON T_TypeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_TypeMessage', old.IdTypeMessage,datetime('now'),'UPDATE');
END;

-- Création du trigger
CREATE TRIGGER Trig_DELETE_T_TypeMessage
AFTER DELETE ON T_TypeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_TypeMessage', old.IdTypeMessage,datetime('now'),'DELETE');
END;
