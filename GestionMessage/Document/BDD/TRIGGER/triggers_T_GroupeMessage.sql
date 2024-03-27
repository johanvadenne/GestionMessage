DROP TRIGGER Trig_INSERT_T_GroupeMessage;
DROP TRIGGER Trig_UPDATE_T_GroupeMessage;
DROP TRIGGER Trig_DELETE_T_GroupeMessage;

-- Création du trigger
CREATE TRIGGER Trig_INSERT_T_GroupeMessage
AFTER INSERT ON T_GroupeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_GroupeMessage', new.IdGroupeMessage,datetime('now'),'INSERT');
END;

-- Création du trigger
CREATE TRIGGER Trig_UPDATE_T_GroupeMessage
AFTER UPDATE ON T_GroupeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_GroupeMessage', old.IdGroupeMessage,datetime('now'),'UPDATE');
END;

-- Création du trigger
CREATE TRIGGER Trig_DELETE_T_GroupeMessage
AFTER DELETE ON T_GroupeMessage
BEGIN
	INSERT INTO T_Log (NomTable,IdTable,DateModif,TypeModif)
	VALUES ('T_GroupeMessage', old.IdGroupeMessage,datetime('now'),'DELETE');
END;
