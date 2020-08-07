Juan Camilo Calvache
Mateo Orrego Cardona
====================================================================================================
[Consideraciones]

Objetos:
	Critter
	Skill
	Player

Metodos:
	ObtainCritter
	LoseCritter
	Calculate (3 Sobrecargas)

Relaciones:
	Un [Player] tiene muchos [Critter],
	Un [Critter] tiene muchos (3) [Skill]
====================================================================================================
[Funcionamiento (En cada Turno)]

1. Seleccionar un Critter con el cual atacar, ingresando el numero que lo identifica (A la izquierda)
2. El programa calcula cual hace primero su acción, y la ejecuta de forma automatica.
3. Seleccionar una acción (Esto puede ocurrir antes o despues de que lo haga el enemigo de acuerdo al punto (2))
4. Se ejecuta una acción seleccionada, y se opera de acuerdo a la lógica del programa.

5. Si la habilidad es de AtkUp o DefUp, incrementa los Current... respectivos del Critter.
6. Si la habilidad es de SpdDown, reduce el CurrentSpeed del Critter ENEMIGO.
7. Si la habilidad es de ataque, ifringe daño, de acuerdo a la tabla de Afinidades.

8. Cuando un critter muere, se invocan los metodos:
	ObtainCritter
	LoseCritter
9. El juego termina cuando uno de los Jugadores se queda sin Critters vivos
	*Los Critters robados NO cuentan como Critters vivos.
====================================================================================================
[Funcionamiento de los Metodos]

1. ObtainCritter: void 
	Recibe como parametro un Critter, y lo añade a la lista de critters del jugador.

2. LoseCritter: Critter
	Recibe como parametro el Critter que murió, y lo elimina de las lista de critters del jugador.
	Luego lo devuelve como un critter, el cual luego lo enviamos al metodo ObtainCritter del otro jugador.

3. Calculate: 3 Sobrecargas: float

	3.1: Calculate()
Calcula un Bonus fijo para Atk y Def, y lo envia como parametro, que luego se usa para modificar los CurrentAttack y CurrentDefense.
Este metodo tiene una condicion basada en la cantidad de usos (Solo puede repetirse 3 veces)

	3.2: Calculate(Critter critter)
Recibe como parametro el Critter enemigo, y lo usa para calcular la reduccion de velocidad.
Este metodo tiene una condicion basada en la cantidad de usos (Solo puede repetirse 3 veces)

	3.3: Calculate(Critter critter, float baseAttack)
Recibe al critter enemigo, y el daño base del critter que esta atacando. Luego compara las afinidades y modifica el: affinityMultiplier.
Luego calcula el total de daño que debe realizar, y lo envia como un float.



