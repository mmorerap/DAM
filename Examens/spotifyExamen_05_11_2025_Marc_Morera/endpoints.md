GET http://localhost:5000/perfils --Obtenir el llistat de tos els perfils

GET by ID http://localhost:5000/perfil/{ID} -- Obtenir un perfil en concret filtat per id

POST http://localhost:5000/perfil

{
  "name": "Primer Perfil",
  "Descripcio": "Descripcio perfil",
  "Estat": 1 ,
	"User_ID": "929BD79C-98A9-464D-AFD6-2365DD2515D2"
}



UPDTE http://localhost:5000/perfil/{ID} --Per fer un update de un perfil

{

  "name": "Primer Perfil",
  "Descripcio": "Descripcio perfil",
  "Estat": 1 ,
	"User_ID": "929BD79C-98A9-464D-AFD6-2365DD2515D2"
}

DELETE http://localhost:5000/perfil/{ID} -- Per Borrar

No hetingut temsp a fer el Endpoint i ado de imatge i perfilImatge ho hages fet igual que Media i pleylist song cambian els valors



