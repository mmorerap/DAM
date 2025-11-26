import argparse

def classifica_animal(pel, pes):
    if pel == 1 and pes < 8:
        return "Gat"
    elif pel == 1 and pes >= 8:
        return "Gos"
    elif pel == 0 and pes > 1:
        return "Ocell"
    elif pel == 0 and pes <= 1:
        return "Gallina"

parser = argparse.ArgumentParser("")

parser.add_argument("tepel", help="Té pel 1 o no té pel 0", type=int)
parser.add_argument("pes", help="Pes de l'animal amb kgs", type=int)

args = parser.parse_args()

pel = args.tepel
pes = args.pes

print("Animal: ",classifica_animal(pel,pes))