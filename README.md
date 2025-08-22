# Re:Start - Jeu de Plateforme 2D

## Présentation du Projet
**ReStart** est un projet de jeu de plateforme 2D développé avec Unity, démontrant l'implémentation de mécaniques de gameplay modernes et de systèmes techniques robustes. Ce projet met l'accent sur la qualité du code, l'architecture logicielle et l'expérience utilisateur.

## Les 3C (Character, Camera, Controls)

### Character (Personnage)
- **Mouvement horizontal** : déplacement fluide avec gestion de la vélocité
- **Saut** : mécanique de saut simple avec détection du sol
- **Wall sliding** : glissement le long des murs verticaux

### Camera
- **Caméra 2D statique** optimisée pour le gameplay de plateforme

### Controls (Contrôles)
- **Input System Unity** moderne remplaçant l'ancien Input Manager
- **Mappage des touches** : Q et D/Flèches droite et gauche + Espace pour le saut

## Architecture Technique

### Design Patterns Implémentés
- **Pattern Command** : encapsulation des actions (ouverture de portes, mécaniques spécialisées)
- **Architecture modulaire** : système extensible pour mécaniques de niveaux spécifiques
- **Découplage logique** : séparation entre input handling et logique métier

### Système de Mouvement (PlayerMovement.cs)

**Fonctionnalités clés :**
- **Détection de collision avancée** : utilisation d'OverlapBox et OverlapCircle pour une précision maximale
- **Système de LayerMask** : séparation logique des différents types de collisions
- **Logique anti-collage** : `horizontalMovement = 0` quand collision détectée
- **Wall sliding physique** : `Mathf.Max(rb.linearVelocity.y, -wallSlideSpeed)`

### Système de Respawn
- **Téléportation instantanée** vers point de départ défini
- **Reset de vélocité** pour éviter les comportements indésirables
- **Détection de collision avec pièges** via LayerMask dédié

### Gestion des Scènes et UI
- **Scene Management** : navigation fluide entre menu principal et niveaux
- **Unity UI (Canvas)** : interface utilisateur responsive
- **Système de sélection de niveaux** : accès modulaire aux différents niveaux

## Défis Techniques Résolus

### 1. Problème de Wall Sticking
**Problème** : Le joueur restait "collé" aux murs en maintenant la direction
**Solution** : Implémentation d'une logique de détection qui annule le mouvement horizontal quand une collision murale est détectée

### 2. Détection de Collision Tilemap
**Problème** : Les Tilemap Colliders 2D posaient des défis pour la détection précise
**Solution** : Remplacement des Raycasts par OverlapBox pour une détection plus fiable

### 3. Input System Integration
**Problème** : Migration de l'ancien Input Manager vers le nouveau Input System
**Solution** : Utilisation d'événements callbacks pour une architecture découplée

### 4. Mécaniques de Niveau Spécialisées
**Problème** : Implémentation de contraintes de gameplay uniques (une seule action, timers automatiques)
**Solution** : Utilisation du pattern Command avec `TimedOpenDoorCommand` pour des mécaniques temporelles complexes

### 5. Système de Spawn Dynamique d'Objets
**Problème** : Génération procédurale d'éléments de gameplay en cours de partie
**Solution** : Implémentation de `SpawnButtonRule` avec gestion dynamique d'objets et séquencement d'événements

## Technologies et Outils

### Moteur et Frameworks
- **Unity 6000.0.51f1** - Moteur de jeu principal
- **C# .NET** - Langage de programmation
- **Input System Package** - Gestion moderne des inputs

### Systèmes de Physique
- **Rigidbody2D** - Physique réaliste du personnage
- **Collider2D** - Détection de collisions
- **Physics2D API** - Raycasting et détection de chevauchement

### Outils de Développement
- **Tilemap System** - Création rapide de niveaux
- **Scene Management** - Navigation entre scènes
- **LayerMask System** - Organisation logique des collisions

### Patterns de Conception
- **Command Pattern** - Encapsulation des actions et découplage input/logique
- **TimedOpenDoorCommand** - Mécaniques temporelles pour niveaux spécialisés
- **SpawnButtonCommand** - Système de génération dynamique d'objets de gameplay

## Métriques de Performance
- **Détection de collision** optimisée avec appels Physics2D minimaux
- **Update/FixedUpdate** séparés pour logique et physique
- **Memory allocation** minimale grâce aux Vector2 réutilisables

## Évolutivité du Code
- **Architecture modulaire** permettant l'ajout facile de nouveaux niveaux
- **Système de LayerMask** extensible pour nouveaux types d'obstacles
- **Pattern Observer** via Input System pour découplage logique
- **Pattern Command** pour mécaniques de niveaux spécialisées

## Niveaux et Mécaniques

### Niveau 1 - Introduction
- **Mécaniques de base** : mouvement libre, saut, wall sliding
- **Apprentissage des contrôles** : familiarisation avec les 3C

### Niveau 2 - "Une Seule Action"
- **Contrainte unique** : une seule action autorisée avant reset
- **Mécaniques temporelles** : timer d'ouverture de porte (5 secondes)
- **Adaptation dynamique** : modification de vitesse contextuelle (moveSpeed = 4)
- **Challenge de précision** : timing et positionnement critiques

### Niveau 3 - "Spawn Button Sequence"
- **Génération dynamique** : apparition séquentielle de boutons interactifs
- **Progression par étapes** : chaque bouton activé fait apparaître le suivant
- **Limite de séquence** : maximum 5 boutons dans la chaîne d'activation
- **Récompense finale** : ouverture automatique de la porte après séquence complète

### Niveau 4 - "Disappearing Traps"
- **Obstacles disparus** : pièges qui disparaissent pendant le niveau
- **Planification stratégique** : le joueur doit anticiper la disparition des obstacles

## Conclusion
Ce projet démontre une maîtrise des concepts fondamentaux du développement de jeux 2D, de l'architecture logicielle propre, et de la résolution de problèmes techniques complexes. L'accent mis sur les 3C garantit une expérience utilisateur de qualité professionnelle.