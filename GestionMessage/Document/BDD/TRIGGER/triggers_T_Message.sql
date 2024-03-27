DROP TRIGGER Trig_INSERT_T_Message;
DROP TRIGGER Trig_UPDATE_T_Message;
DROP TRIGGER Trig_DELETE_T_Message;

-- Création du trigger
CREATE TRIGGER Trig_INSERT_T_Message
AFTER INSERT ON T_Message
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_Message', new.IdMessage,datetime('now'),'INSERT');
END;

-- Création du trigger
CREATE TRIGGER Trig_UPDATE_T_Message
AFTER UPDATE ON T_Message
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_Message', old.IdMessage,datetime('now'),'UPDATE');
END;

-- Création du trigger
CREATE TRIGGER Trig_DELETE_T_Message
AFTER DELETE ON T_Message
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_Message', old.IdMessage,datetime('now'),'DELETE');
END;
