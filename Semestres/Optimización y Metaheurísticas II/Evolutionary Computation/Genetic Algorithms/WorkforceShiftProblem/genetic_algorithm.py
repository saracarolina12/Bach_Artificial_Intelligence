import numpy as np

# This implementation maximizes the objective function
# It implements an uniform crossover
# The mutation get a random a permutation

class GeneticAlgorithm:
    def __init__(self, fitness, args, popSize, nGen, pRep, pMut, dim, init, debug): # Objective function, arguments of the function, Population size, number of generations, reproduction probability, mutation probability, dimensions of the solution (height, width, minVal, maxVal)
        assert callable(fitness), 'fitness is not a function'
        assert isinstance(args, tuple), 'fitness is not tuple'
        assert isinstance(popSize, int), 'popSize is not int'
        assert isinstance(nGen, int), 'nGen is not int'
        assert isinstance(pRep, float), 'pRep is not float'
        assert isinstance(pMut, float), 'pMut is not float'
        assert isinstance(dim, tuple) and len(dim) == 4, 'dim is not valid'
        assert isinstance(debug, bool), 'debug is not bool'
        assert init is None or isinstance(init, np.ndarray), 'initial population is not valid'

        self.fitness = fitness
        self.args = args
        self.popSize = popSize
        self.nGen = nGen
        self.pRep = pRep
        self.pMut = pMut
        self.population = init if not init is None else None
        self.height, self.width, self.minValue, self.maxValue = dim
        self.nEvaluations = 0
        self.fitnesses = None
        self.debug = debug
    
    def initPopulation(self):
        self._initPopulation()
        assert isinstance(self.population, np.ndarray), 'r is not np.array'
    def _initPopulation(self):
        if not self.population is None: return
        self.population = np.random.randint(self.minValue, self.maxValue, (self.popSize, self.height, self.width))

    def getFitness(self, individual):
        assert individual.shape == (self.height, self.width), 'individual is not valid'
        r = self._getFitness(individual)
        return r
    def _getFitness(self, individual):
        self.nEvaluations += 1
        return self.fitness(individual, *self.args)
    
    def rouletteSelection(self, k = 2, reverse = False): #Number of individuals to be selected
        assert isinstance(k, int), 'k is not int'
        assert self.fitnesses.all() != None, 'fitnesses has not been initialized'
        r = self._rouletteSelection(k, reverse)
        assert isinstance(r, np.ndarray) and r.shape[0] == k, 'r is not the expected result'
        return r
    def _rouletteSelection(self, k, reverse):
        norm = np.copy(self.fitnesses)
        norm = self.fitnesses - np.min(self.fitnesses)
        if (norm == 0).any(): norm = norm + 0.1
        if reverse: norm = 1 / norm
        norm = norm / np.sum(norm)
        return np.random.choice(self.popSize, k, False, norm)

    def crossover(self, parentOne, parentTwo):
        assert parentOne.shape == (self.height, self.width), "parentOne doesn't have the expected shape"
        assert parentTwo.shape == (self.height, self.width), "parentTwo doesn't have the expected shape"
        r = self._crossover(parentOne, parentTwo)
        assert r.shape == (self.height, self.width), "r doesn't have the expected shape"
        return r
    def _crossover(self, parentOne, parentTwo):
        child = np.copy(parentOne)
        if np.random.random() < self.pRep:
            numberOfRows = np.random.randint(1, self.height)
            rowsToSwap = np.random.choice(self.height, numberOfRows, False)
            child[rowsToSwap] = np.copy(parentTwo[rowsToSwap])
        elif np.random.random() < 0.5: child = np.copy(parentTwo)
        return child

    def mutation(self, child):
        assert child.shape == (self.height, self.width), "child doesn't have the expected shape"
        r = self._mutation(child)
        assert r.shape == (self.height, self.width), "r doesn't have the expected shape"
        return r
    def _mutation(self, child):
        if np.random.random() < self.pMut:
            numberOfRows = np.random.randint(1, self.height)
            rowsToReset = np.random.choice(self.height, numberOfRows, False)
            for i in rowsToReset:
                child[i, :-1] = np.random.permutation(child[i, :-1]) #Specific to the problem
        return child

    def solve(self):
        r = self._solve()
        assert isinstance(r, dict), 'r is not dict'
        return r
    def _solve(self):
        bestTracker = []
        self.initPopulation()
        self.fitnesses = np.array([self.getFitness(i) for i in self.population])
        eliteFitness, elite = -1e10, None
        for i in range(self.nGen):
            bestTracker.append(eliteFitness)
            if self.debug:
                if i % (self.nGen // 10) == 0: print(eliteFitness)
            newPopulation, newFitnesses = np.zeros_like(self.population), np.zeros_like(self.fitnesses)
            for c in range(self.popSize):
                parents = self.rouletteSelection()
                child = self.crossover(*self.population[parents])
                child = self.mutation(child)
                newPopulation[c] = np.copy(child)
                newFitnesses[c] = self.getFitness(child)
            possibleElite = np.argmax(newFitnesses)
            pEFitness = newFitnesses[possibleElite]
            if pEFitness > eliteFitness:
                eliteFitness = pEFitness
                elite = np.copy(newPopulation[possibleElite])
            else: 
                toReplace = self.rouletteSelection(1, True)
                newPopulation[toReplace] = np.copy(elite)
            self.population = np.copy(newPopulation)
            self.fitnesses = np.copy(newFitnesses)
        return {"solution": elite, "fitness": eliteFitness, "callsToFunction": self.nEvaluations, "bestTracker": bestTracker[1:]}
            

def genetic_algorithm(fitness, args = (), popSize = 10, nGen = 10, pRep = 0.5, pMut = 0.5, dim = (5, 5, 0, 5), init = None, debug = False):
    gA = GeneticAlgorithm(fitness, args, popSize, nGen, pRep, pMut, dim, init, debug)
    return gA.solve()




