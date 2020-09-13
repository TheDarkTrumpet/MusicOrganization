"""
main.py
Main entry when executing createm3u as a 'program'

Use: python createm3u <base_path>
"""

import click
from createm3ulib import createm3ulib

def print_help(ctx, opts, args):
    if args is False:
        return
    click.echo(ctx.get_help())
    ctx.exit()

@click.command()
@click.argument('basedir')
@click.option("-d", "--dryrun", is_flag=True, help="Parse but not create m3us")
def main(basedir, dryrun):
    cm3u = createm3ulib(basedir, dryrun)
    cm3u.do()

if __name__ == '__main__':
    main()