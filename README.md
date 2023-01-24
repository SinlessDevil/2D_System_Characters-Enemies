# 2D System Characters Enemies

In this repository I would like to tell you simply about the characters, as well as the enemy and his logic in general

# Game Play

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/GamePlay_1.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/GamePlay_2.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/GamePlay_3.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/GamePlay_4.png)

# Game logic

>Character&Controller

The first thing I did was to create a character, and I was starting from an abstraction. My character can move to the left and right, and also to move to the right.

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/Character.png)

Next I made a controller, since we are referring to the abstraction, then we can put any character

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/OldCharacterController.png)

Later, I remembered about the new character control system, and decided to rewrite it . The pluses of the new system are that it's more flexible and safer from a code point of view 

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/NewCharacterController.png)

>СameraFollower

I made a security camera accordingly. It is also on the abstraction because it has two implementations in Update and FixedUpdate - this is convenient in terms of if you have different tracking and in different Update

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/Сmera_Follower.png)

>State Machine

Next I made the State Machine for both character and enemy animations

State is a behavioral design pattern that allows an object to change the behavior when its internal state changes.

The pattern extracts state-related behaviors into separate state classes and forces the original object to delegate the work to an instance of these classes, instead of acting on its own.

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/State_Machine_One.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/State_Machine_Two.png)

>Health System

Also for example I made Health System on the abstraction, because we will have two implementations, both for the enemy and for the character. And at the same time using the Observer pattern

Observer is a behavioral design pattern that allows some objects to notify other objects about changes in their state.

The Observer pattern provides a way to subscribe and unsubscribe to and from these events for any object that implements a subscriber interface.

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/HealthSystemTwo.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/HealthSytemOne.png)

>Enemy Behavior System

The enemy was the most difficult thing I ever did. In general, I created the core of the whole module is EnemyBehaviorByDefould. It stores all the basic links to its other components Attack , Move , Detection

In some kind of a nucleus I recreated the Mediator patch.

Mediator is a behavioral design pattern that reduces coupling between components of a program by making them communicate indirectly, through a special mediator object.

The Mediator makes it easy to modify, extend and reuse individual components because they’re no longer dependent on the dozens of other classes.

Number 1 is the logic of patrolling 
at number 2 the logic of attacking and tigerizing the enemy

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/EnemyCenterBehavior.png)

The first thing I'll tell you about Advance

Created an abstraction taking into account that there may be several implementations, movement is such a thing you never know what can change there and then created a simple patrol with a delay

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/EnemyMove.png)

Then I did Detection through triggers, created an abstraction after which there were two implementations. And at the end I wrote a not very successful script, but in it I collected all the links and subscripts to classes and methods for convenience

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/EnemyDetectionTwo.png)

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/EnemyDetectionOne.png)

At the end I made a block of Attacks, through Collision. Here I made a mistake, I forgot to subscribe to the event and as a result the code is not working. The enemy can waving his fists all he wants but the damage will not do =(

![Image alt](https://github.com/SinlessDevil/2D_System_Characters-Enemies/blob/main/EnemyAttack.png)

---

That's all for now, I'll come back later and fix all the mistakes !!!
