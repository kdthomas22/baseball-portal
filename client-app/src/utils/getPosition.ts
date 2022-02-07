export const getPosition = (position: number): string => {
    switch (position)
    {
  case 1: {
    return "P"
        }
    case 2: {
        return "C"
    }
    case 3: {
        return "1B"
    }
    case 4: {
        return "2B"
    }
    case 5: {
        return "3B"
    }
    case 6: {
        return "SS"
    }
    case 7: {
        return "LF"
    }
    case 8: {
        return "CF"
    }
    case 9: {
        return "RF"
    }
    case 10: {
        return "DH"
    }
    case 11: {
        return "SP"
    }
    case 12: {
        return "RP"
    }
    default: {
        return "Unknown"
    }
    }
}