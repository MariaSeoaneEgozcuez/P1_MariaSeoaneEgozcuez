**-> PlayerController.cs**

Este es el script que permite el control del jugador y define sus características. Primero, se recogen en el Start las referencias del Rigidbody (para la física) y el Animator (para las animaciones). Tras esto, pasamos al Update, donde iniciamos con el movimiento del 
jugador. Para esto, leemos el input (horizontal -> A/D o flechas derecha/izquierda | vertical -> W/S o flechas arriba/abajo). Con esto, calculamos la dirección normalizada y si hay movimiento, orientamos el personaje hacia esa dirección (Quaternion.LookRotation). Aplicamos
dicha velocidad a nuestro Rigidbody para provocar el movimiento físico y añadimos la funcionalidad de duplicar la velocidad si presionamos el shift. Para la ejecución del salto, nos aseguramos de que se esté presionando el input de la barra espaciadora y a la vez que 
nuestro jugador tenga el atributo isGrounded en True (para evitar salto infinito). Si esto se cumple, y estamos en un objeto de tag "Floor", aplicamos una fuerza hacia arriba (AddForce con Impulse) para ejecutar el salto. Ahora, controlamos los parámetros del Animator para ejecutar las animaciones.
"Walk" se activa si hay movimiento y "Jump" se activa si la velocidad vertical es distinta de 0 (ya que eso significaría que estamos saltando). 

**-> MovingPlatform.cs**

Este es el script que ejecuta el movimiento de la plataforma que debe moverse horizontalmente (de izquierda a derecha) con un movimiento continuo, oscilando entre dos posiciones. Para esto, defino en el script dos variables de posición, la primera "m_posinicial",
cogerá la posición inicial de la plataforma. La segunda, "m_posfinal" cogerá la posición original desplazándola 2 unidades a la derecha.

Ahora, en un FixedUpdate hacemos el movimiento continuo. Utilizo la función Vector3.lerp para poder mover la plataforma de forma controlada, suave y constante entre la posición final e inicial. Utilizo la variable "lerpValue" para indicar hacia qué posición debe moverse la
plataforma. Este valor oscila entre 0 y 1, de forma que cuando llega a 1, cambia de dirección y viceversa, de forma que la plataforma se mueva continuamente. La velocidad de movimiento estará controlada por la variable "m_speed".

Utilizamos un OnCollisionStay para evitar que el jugador se caiga de la plataforma en movimiento, de forma que si un GameObject con la tag "Player" entrá en contacto con la plataforma, el GameObject se hace hijo de la plataforma. De esta forma, el jugador se moverá con la
plataforma, pero conservará la funcionalidad propia de poder moverse individualmente. Cuando el GameObject deje de estar en contacto con la plataforma, dejará de ser hija de esta.

**-> FallingPlatform.cs**

Este es el script que ejecuta el movimiento de la plataforma que debe caer tras caer el jugador en ella. Debe caer y volver a su posición original tras una espera. En el Start guardamos la posición inicial de la plataforma ("posInicial") y la posición final a la que debe "caer"
("posfinal"). Cuando detectemos colisión a través de un OnCollisionEnter, obtenemos la normal del contacto. Si la colisión no viene desde arriba, la ignoramos. Sin embargo, si: 1. el objeto tiene el tag "Player", 2. no está ya en proceso de "caer" y 3. el contacto es desde arriba,
entonces activamos collision = true e iniciamos una corrutina con StartCoroutine para controlar la caída. En nuestra corrutina, esperamos 1 segundo con Timer(), hacemos que la posición "caiga" hacia posfinal usando Vector3.MoveTowards, hacemos que la plataforma espere de nuevo
otro segundo al llegar abajo, subimos la plataforma de nuevo a posinicial y permitimos que la plataforma pueda volver a activarse cambiando collision = false.

**-> CamController.cs**

Este es el script que controla la cámara para que siga a nuestro jugador. Tenemos una variable target, que es nuestro jugador. En un LateUpdate, colocamos la cámara en la posición del target con un desplazamiento para que quede visualmente lo suficientemente lejos del jugador
y con una angulación para tener una tercera persona. De esta forma, seguimos continuamente la posición del jugador desde esa distancia.
