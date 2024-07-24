# Procediverso

Gestada en el marco de la cursada de de Taller Diseño Multimedial 5, en la Facultad de Artes de la UNLP en el año 2023, como tesina de grado para la licenciatura en diseño multimedia, Procediverso se desarrolló partiendo de mis inquietudes por el arte generativo y el diseño de escenarios para videojuegos, para finalizar siendo montada y exhibida en el Festival Artimañas, realizado en diciembre del mismo año de manera abierta y gratuita, en la Sede Fonseca de la Facultad de Artes.

Siempre con el foco en los en los entornos virtuales y cómo nos vinculamos con ellos, se desarrolló para el medio de realidad virtual a través de Unity, para potenciar su factor inmersivo al tratarse de una experiencia de exploración surrealista.

Lee mas sobre Procediverso y su desarrollo [AQUI](https://procediweb.netlify.app/) o en mi [PORTFOLIO](https://alvaroperezdominguezportfolio.netlify.app/001-procediverso)

Proyecto de Unity basado en el proyecto de código abierto [Wave Function Collapse](https://github.com/marian42/wavefunctioncollapse) de Marian Kleineberg.

#### Jugar

Proximamente en itch.io

## Créditos

Este proyecto está basado en [Wave Function Collapse](https://marian42.de/article/wfc/) creado por Marian Kleineberg.

### Licencia Original

Este proyecto utiliza la [Licencia MIT](LICENSE) otorgada por Marian Kleineberg.

### Cambios Realizados

El juego original de Marian Kleineberg utiliza un conjunto de aproximadamente 100 bloques arquitectónicos. Su sistema de construcción se basa en el algoritmo “Wave Function Collapse”, para generar su ciudad infinita mediante estrategias y conceptos como entropía, orden y azar.

Resolví que el proyecto sea consciente de la cantidad de piezas que colocaba, y así limitarla. Al quitar la infinidad a la construcción arquitectónica, los aspectos de la variabilidad se relucen.
En lugar de crear un mundo interminable y coherente a una estética determinada, se crean pequeños escenarios que comparten su arquitectura, pero con configuraciones morfológicas completamente diferentes, únicas e identitarias.

También aplicaría variabilidad a las características formales de las piezas individuales, como color, brillo, opacidad, y otros, para que sean diferentes en cada ocasión. Para luego aplicar lógicas equivalentes al color, intensidad, tamaño y brillo a elementos como el cielo, el sol y filtros en la visión.

De esta forma pude no sólo construir escenarios irrepetibles, sino también ofrecer entornos cuyos factores e indicios espaciales estimulan de manera única los sentidos del usuario, generando interpretaciones y experiencias diferentes al incentivar su creatividad personal.

---

## Contenido Original

### Wave Function Collapse

An infinite, procedurally generated city, assembled out of blocks using the Wave Function Collapse algorithm with backtracking.

Read more about this project [here](https://marian42.de/article/wfc/) and about the WFC algorithm [here](https://github.com/mxgmn/WaveFunctionCollapse).

#### Play

Download the game on Itch.io: [https://marian42.itch.io/wfc](https://marian42.itch.io/wfc)  
Currently, there is no gameplay, you can only walk around and look at the scenery.

Keyboard Controls: WASD for walking, Space to jump, Shift to run, Ctrl to jetpack.  
XBOX Controls: Left Stick for walking, right stick for looking around, A to jump, LB to run, RB to jetpack

Flight mode: Use M to toggle between flight mode and normal mode. In flight mode, you fly across the world, without any controls.

#### Editing the module set

By changing the module set, you can make some changes to the world generation without writing code.
You can disable or enable modules, change their spawn probability, their connectors, their neighbor rules or you can add new ones.
Here is how to do it:

1. Open the `Prototypes` scene.
2. Edit the blocks in the scene. You'll mostly change values in the `ModulePrototype` components.
3. Select the "Prototypes" game object in the hierarchy and apply your changes to the prefab (Overrides -> Apply all).
4. Select the file "ModuleData" in the asset folder.
5. Click "Create module data".
6. Optional: Click "Simplify module data". This takes some time, but will make world generation faster.
7. Save your work and go back to the `Game` scene. You can now use your updated module set.

#### Generating worlds in the editor

There are different ways to generate worlds in the editor:

- Select the Map object. In the `MapBehaviour` component, select a size and click "Initialize NxN area".
- Select the "Area Selector" object.
  Move and scale it to select an area, then use the "Generate" button to generate a map.
- Use the "Slot Inspector" object to show details about a single position.
  It shows you which modules can be spawned at that position and lets you select modules manually.

If you want to enter Play mode without losing your map, disable the "Generate Map Near Player" and the "Occlusion culling" script.
Note that none of the components serialize, so you can't change the map once it has been serialized.
That means that you can't change your map in Play mode unless you initialized it in Play mode.
