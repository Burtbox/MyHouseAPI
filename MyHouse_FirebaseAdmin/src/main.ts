/**
 * Some predefined delays (in milliseconds).
 */
export enum Delays {
  Short = 500,
  Medium = 2000,
  Long = 5000,
}

/**
 * Returns a Promise<string> that resolves after given time.
 *
 * @param {string} name - A name.
 * @param {number=} [delay=Delays.Medium] - Number of milliseconds to delay resolution of the Promise.
 * @returns {Promise<string>}
 */
function delayedHello(name: string, delay: number = Delays.Medium): Promise<string> {
  return new Promise<string>(
    (resolve: (value?: string | PromiseLike<string>) => void) => setTimeout(
      () => resolve(`Hello, ${name}`),
      delay,
    ),
  );
}

// Below are examples of using TSLint errors suppression
// Here it is supressing missing type definitions for greeter function

export async function greeter(name) { // tslint:disable-line typedef
  // tslint:disable-next-line no-unsafe-any
  console.log("started!");
  return await delayedHello(name, Delays.Short);
}

console.log("is anybody in there?");