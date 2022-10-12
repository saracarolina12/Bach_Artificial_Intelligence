import numpy as np

class DifferentialEvolution:
    def __init__(self, func, bounds, popSize, cR, nGen, args):
        assert isinstance(func, function), 'func is not function'
        assert isinstance(bounds, np.ndarray), 'bounds is not np.ndarray'
        assert isinstance(args, np.ndarray), 'args is not np.ndarray'
        assert isinstance(popSize, int), 'popSize is not int'
        assert isinstance(cR, float), 'cR is not float'
        assert isinstance(nGen, int), 'nGen is not int'
        self.func = func
        self.bounds = bounds
        self.args = args 
        self.popSize = popSize
        self.cR = cR
        self.nGen = nGen
        self.nVar = bounds.shape[0]
        self.nIt = 0

    def _getFitness(self, i):
        assert isinstance(i, np.ndarray), 'individual is not np.ndarray'
        assert i.shape[0] == self.nVar, "individual doesn't have size == nVar"
        r = self.getFitness(i)
        assert isinstance(r, float), 'r is not float'
        return r
    def getFitness(self, i):
        self.nIt += 1
        return self.func(i, *self.args)

    def _mutation(self, i):
        assert isinstance(i, np.ndarray), 'i is not np.ndarray'
        r = self.mutation(i)
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def mutation(self, i):
        i = i.copy()
        rand = np.random.randint(low=0, high=self.nVar,  size=3)
        r1 = i[rand[0]]
        r2 = i[rand[1]]
        r3 = i[rand[2]]
        F = np.random.uniform(0,2)
        p2 = F*(np.subtract(r2,r3))
        return np.subtract(r1,p2)


    def _crossover(self, pOne, pTwo):
        assert isinstance(pOne, np.ndarray), 'pOne is not np.ndarray'
        assert isinstance(pTwo, np.ndarray), 'pTwo is not np.ndarray'
        r = self.crossover(pOne, pTwo)
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def crossover(self, pOne, pTwo):
        pass

    def _selection(self, iOne, iTwo):
        assert isinstance(iOne, np.ndarray), 'iOne is not np.ndarray'
        assert isinstance(iTwo, np.ndarray), 'iTwo is not np.ndarray'
        r = self.selection(iOne, iTwo)
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def selection(self, iOne, iTwo):
        pass

    def _initPopulation(self):
        r = self.initPopulation()
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
        return r
    def initPopulation(self):
        pass
    
    def _solve(self):
        r = self.solve()
        assert isinstance(r, np.ndarray), 'r is not np.ndarray'
    def solve(self):
        pass
    
    
def differential_evolution(func, bounds, popSize, cR, nGen, args):
    dE = DifferentialEvolution(func, bounds, popSize, cR, nGen, args = ())
    return dE.solve()