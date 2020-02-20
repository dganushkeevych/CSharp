def weather_info(temp):
    c = convertToCelsius(temp)
    if (c < 0):
        return (f"{c} is freezing temperature")
    else:
        return (f"{c} is above freezing temperature")


def convertToCelsius(temperature):
    celsius = (temperature - 32) * (5.0/9.0)
    return celsius
