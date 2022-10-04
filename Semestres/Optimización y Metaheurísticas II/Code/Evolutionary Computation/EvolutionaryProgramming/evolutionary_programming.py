import numpy as np

class EvolutionaryProgramming:
    def __init__(self, func, bounds, args = (), popsize = 1):
        self.func = func
        self.bounds = np.array(bounds)
        self.args = args
        self.popsize = popsize
        self.population = None
        self.fitness = None

    def mutation(self):
        nPopulation = self.population.copy()
        def mutate(individual):
            print(individual)
            nvar = len(self.bounds)
            alpha = 0.2
            r = [v + (np.random.normal(0, individual[i + nvar])) if i < nvar else v * (1 + np.random.normal(0, alpha)) for i, v in enumerate(individual)]
            return r
        nPopulation = [mutate(i) for i in nPopulation]
        # print(nPopulation)
        return nPopulation


    def survivor_selection(self, mutated):
        print("survivor")
        print(np.concatenate((self.population, mutated)))

    def init_population(self):
        nvar = len(self.bounds)
        self.population = np.zeros((self.popsize, nvar*2))
        self.fitness = np.zeros((self.popsize))
        for v in range(nvar):
            vmin, vmax = self.bounds[v, 0], self.bounds[v, 1]
            vmut = np.abs(vmax - vmin) / 10
            self.population[:, v] = np.random.uniform(vmin, vmax, (self.popsize))
            self.population[:, v + nvar] = np.abs(np.random.normal(0, vmut, (self.popsize))) + 0.001

        for i in range(self.popsize):
            P = self.population[i, :nvar]
            self.fitness[i] = self.func(P, *self.args)

            print(self.population[i, :nvar], self.fitness[i])

        print(self.population)
    def solve(self):
        self.init_population()
        self.mutation()
        self.survivor_selection(self.mutation())
        # P: el arreglo con la solucion
        # nit: numero de generaciones
        # fun: fitness del mejor individuo al terminar la ejecucion
        # nfev: numero de veces que se manda a llamar la funcion
        return
        return P, nit, fun, nfev 
def evolutionary_programming(func, bounds, args = (), popsize = 30):
    ep = EvolutionaryProgramming(func, bounds, args, popsize)
    return ep.solve()