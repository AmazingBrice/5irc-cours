-- DELETE FROM public."T_J_FAVORI_FAV";
-- DELETE FROM public."T_E_COMPTE_CPT";
-- DELETE FROM public."T_E_FILM_FLM";

INSERT INTO public."T_E_FILM_FLM"("FLM_TITRE", "FLM_SYNOPSIS", "FLM_DATEPARUTION", "FLM_DUREE", "FLM_GENRE", "FLM_URLPHOTO")
VALUES ('Avengers : L''�re d''Ultron', 'Alors que Tony Stark tente de relancer un programme de maintien de la paix jusque-l� suspendu, les choses tournent mal et les super-h�ros Iron Man, Captain America, Thor, Hulk, Black Widow et Hawkeye vont devoir � nouveau unir leurs forces pour combattre le plus puissant de leurs adversaires : le terrible Ultron, un �tre technologique terrifiant qui s''est jur� d''�radiquer l''esp�ce humaine.', '2015-09-15', 120, 'Fantastique', null);
INSERT INTO public."T_E_FILM_FLM"("FLM_TITRE", "FLM_SYNOPSIS", "FLM_DATEPARUTION", "FLM_DUREE", "FLM_GENRE", "FLM_URLPHOTO")
VALUES ('Lucy', 'A la suite de circonstances ind�pendantes de sa volont�, une jeune �tudiante voit ses capacit�s intellectuelles se d�velopper � l''infini. Elle colonise son cerveau, et acquiert des pouvoirs illimit�s.', '2015-09-15', 90, 'Science-fiction', null);
INSERT INTO public."T_E_FILM_FLM"("FLM_TITRE", "FLM_SYNOPSIS", "FLM_DATEPARUTION", "FLM_DUREE", "FLM_GENRE", "FLM_URLPHOTO")
VALUES ('Virgin suicides', null, '2015-09-15', 90, 'Drame', null);

INSERT INTO public."T_E_COMPTE_CPT"("CPT_MEL", "CPT_NOM", "CPT_PRENOM", "CPT_TELPORTABLE", "CPT_RUE", "CPT_CP", "CPT_VILLE", "CPT_PAYS", "CPT_LATITUDE", "CPT_LONGITUDE", "CPT_PWD")
	VALUES ('paul.durand@gmail.com', 'DURAND', 'Paul', null, 'Chemin de Bellevue', '74940', 'Annecy-le-Vieux', 'France', 45.921154, 6.153794, 'Info123/');
INSERT INTO public."T_E_COMPTE_CPT"("CPT_MEL", "CPT_NOM", "CPT_PRENOM", "CPT_TELPORTABLE", "CPT_RUE", "CPT_CP", "CPT_VILLE", "CPT_PAYS", "CPT_LATITUDE", "CPT_LONGITUDE", "CPT_PWD")
	VALUES ('marc.dupond@gmail.com', 'DUPOND', 'Marc', '0601010101', '10 rue des 3 Rois', '69007', 'Lyon', 'France', 45.753979, 4.842775, 'Info123/');
INSERT INTO public."T_E_COMPTE_CPT"("CPT_MEL", "CPT_NOM", "CPT_PRENOM", "CPT_TELPORTABLE", "CPT_RUE", "CPT_CP", "CPT_VILLE", "CPT_PAYS", "CPT_LATITUDE", "CPT_LONGITUDE", "CPT_PWD")
	VALUES ('pascal.poison@gmail.com', 'POISON', 'Pascal', '0601010102', '43 Boulevard du 11 Novembre 1918', '69100', 'Villeurbanne', 'France', 45.779122, 4.864483, 'Info123/');
INSERT INTO public."T_E_COMPTE_CPT"("CPT_MEL", "CPT_NOM", "CPT_PRENOM", "CPT_TELPORTABLE", "CPT_RUE", "CPT_CP", "CPT_VILLE", "CPT_PAYS", "CPT_LATITUDE", "CPT_LONGITUDE", "CPT_PWD")
	VALUES  ('vincent.vivant@gmail.com', 'VIVANT', 'Vincent', '0601010101', 'Rue de la gare', '74000', 'Annecy', 'France', 45.900870, 6.121609, 'Info123/');

INSERT INTO public."T_J_FAVORI_FAV"("CPT_ID", "FLM_ID") VALUES (1, 1);
INSERT INTO public."T_J_FAVORI_FAV"("CPT_ID", "FLM_ID") VALUES(1, 2);
