# ReStart

## Description
ReStart est un jeu de plateforme 2D développé avec Unity dans le cadre d'un projet étudiant qui a pour ambition d'être réutilisé par la suite. Le joueur doit naviguer à travers des niveaux similaires remplis d'obstacles et de pièges pour atteindre l'objectif : la sortie.

## Gameplay

### Contrôles
- **Déplacement** : Flèches directionnelles : droite, gauche ou Q et D
- **Saut** : Barre d'espace

### Mécaniques de jeu
- **Wall sliding** : glissement contrôlé le long des murs verticaux
- **Système de respawn** : retour automatique au point de départ en cas de contact avec les pièges
- **Détection précise** des collisions avec les sols, murs et obstacles

## Premier Niveau

### Objectif
Naviguer du point de départ jusqu'à la sortie en évitant les pièges.

### Obstacles
- **Piques**
- **Murs et plateformes**


## Fonctionnalités techniques
- **Input System Unity** pour une gestion moderne des contrôles
- **Tilemap Colliders** pour la création de la map
- **LayerMask** pour la détection sélective des collisions
- **OverlapCircle/OverlapBox** pour une détection précise

## Développement
Projet développé en C# avec Unity Engine, mettant l'accent sur :
- La fluidité du mouvement du joueur
- La résolution des problèmes de collision
- L'implémentation de mécaniques de plateforme modernes
