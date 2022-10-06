import numpy as np

class EvolutionaryProgramming:
    def __init__(self, func, bounds, args = (), popsize = 30, ngen = 50):
        self.func = func
        self.bounds = np.array(bounds)
        self.args = args
        self.popsize = popsize
        self.population = None
        self.fitness = None
        self.ngen = ngen
        self.nit = 0
        self.nvar = self.bounds.shape[0]

    def getFitness(self, P, X, Y):
        self.nit += 1
        return self.func(P, X, Y)

    def mutation(self):
        nPopulation = self.population.copy()
        def mutate(individual):
            #print(individual)
            alpha = 0.2
            r = [v + (np.random.normal(0, individual[i + self.nvar])) if i < self.nvar else v * (1 + np.random.normal(0, alpha)) for i, v in enumerate(individual)]
            return r
        nPopulation = [mutate(i) for i in nPopulation]
        return nPopulation

    def survivor_selection(self, mutated):
        self.population = np.concatenate((self.population, mutated))
        self.fitness = [self.getFitness(i[:self.nvar], *self.args) for i in self.population]
        sortedIndices = np.argsort(self.fitness)
        self.population = self.population[sortedIndices][0: self.population.shape[0]//2]
        self.fitness = np.sort(self.fitness)[0: self.population.shape[0]//2]

    def init_population(self):
        self.population = np.zeros((self.popsize, self.nvar*2))
        self.fitness = np.zeros((self.popsize))
        for v in range(self.nvar):
            vmin, vmax = self.bounds[v, 0], self.bounds[v, 1]
            vmut = np.abs(vmax - vmin) / 10
            self.population[:, v] = np.random.uniform(vmin, vmax, (self.popsize))
            self.population[:, v + self.nvar] = np.abs(np.random.normal(0, vmut, (self.popsize))) + 0.001

        '''
        for i in range(self.popsize):
            P = self.population[i, :self.nvar]
            self.fitness[i] = self.getFitness(P, *self.args)

            print(self.population[i, :self.nvar], self.fitness[i])

        print(self.population)
        '''
    def solve(self):
        self.init_population()
        for _ in range(self.ngen):
            self.survivor_selection(self.mutation())

        # P: el arreglo con la solucion
        # nit: numero de generaciones
        # fun: fitness del mejor individuo al terminar la ejecucion
        # nfev: numero de veces que se manda a llamar la funcion
        return {"P": self.population[0,:self.nvar], "nIt": self.ngen, "fun": self.fitness[0], "nFev": self.nit}
def evolutionary_programming(func, bounds, args = (), popsize = 30, ngen = 50):
    ep = EvolutionaryProgramming(func, bounds, args, popsize, ngen)
    return ep.solve()